using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SimpleFeedReader;

namespace SimpleOverlay
{
    class FeedController
    {
        private List<Thread> threads = new List<Thread>();

        public FeedController(List<string> urls)
        {
            foreach(string url in urls)
                threads.Add(new Thread(() => ReadFeed(url)));

            foreach(Thread t in threads)
                t.Start();
        }

        public void Close()
        {
            foreach (Thread t in threads)
                t.Abort();
        }

        public void ReadFeed(string url)
        {
            //Notification notification;
            List<string> titels = FeedFileReader(url);
            var reader = new FeedReader();

            while (true)
            {                
                var items = reader.RetrieveFeed(url);

                int posOffset = 0;

                foreach (var i in items)
                {
                    if (titels.Contains(i.Title))
                        continue;

                    //Debug.WriteLine(string.Format("{0}\t{1}\t{2}", i.Date.ToString("g"), i.Title, i.Summary));
                    //notification = new Notification(i.Title, i.Summary, i.Uri.Host, posOffset);
                    //notification.Show();
                    Notification.Create(i.Title, i.Summary, i.Uri.Host, posOffset);
                    Thread.Sleep(20);
                    posOffset++;

                    titels.Add(i.Title);
                    FeedFileWriter(url, i.Title);
                }
                Thread.Sleep(60000);
            }
        }

        private void FeedFileWriter(string url, string title)
        {
            string path = GetPathFromUrl(url);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(title);
            }
        }

        private List<string> FeedFileReader(string url)
        {
            List<string> res = new List<string>();
            string path = GetPathFromUrl(url);

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while(sr.Peek() >= 0)
                    {
                        res.Add(sr.ReadLine());
                    }
                }
            }

            return res;
        }

        private string GetFileNameFromUrl(string url)
        {
            var s = url.Split(new string[] { "//" }, StringSplitOptions.None);
            if (s.Length > 1)
            {
                s = s[1].Split(new string[] { "/" }, StringSplitOptions.None);
                if (s.Length >= 1)
                    return s[0];
            }
            return "nonamefound";
        }

        private string GetPathFromUrl(string url)
        {
            string name = GetFileNameFromUrl(url);
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\" + name + ".txt";
        }
    }
}

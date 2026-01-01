using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher
{


    public class NewsArticle
    {


        public string Title { get; }

        public string Content { get; }


      public NewsArticle(string Title , string Content)
        {

            this.Title = Title;
            this.Content = Content;

        }


    }


    public class NewPublisher
    {

        public event EventHandler<NewsArticle> NewsArticleNotif;


        public void PublisherNews(string Title , string Content)
        {


            var Article = new NewsArticle(Title, Content);

            OnPublisheNews(Article);

        }


        protected virtual void OnPublisheNews(NewsArticle Article)
        {

            NewsArticleNotif?.Invoke(this, Article);

        }


    }


    public class NewSub
    {

        public string Name { get; set; }


        public NewSub(string Name)
        {

            this.Name = Name;

        }

        public void Subscribe(NewPublisher publisher )
        {

            publisher.NewsArticleNotif += HandlePublishNews;

        }

        public void UnSubcribe(NewPublisher publisher)
        {
            publisher.NewsArticleNotif -= HandlePublishNews;
        }

        public void HandlePublishNews(object sender , NewsArticle article)
        {


            Console.WriteLine($"Subscriber Name :   {Name} ");
            Console.WriteLine($"Title           :   {article.Title}");
            Console.WriteLine($"Content         :   {article.Content}");



        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {

            NewPublisher publisher = new NewPublisher();

          
            NewSub subscriber = new NewSub("Mohamed");

            subscriber.Subscribe(publisher);

            publisher.PublisherNews("Brking News", "This Part is Subscribe to the event for raise it");

            Console.WriteLine();
            Console.WriteLine();

            NewSub subscriber2 = new NewSub("Youssef");

            subscriber2.Subscribe(publisher);

            publisher.PublisherNews("Meteo News", "Now the Publisher is send for two subscriber");

            Console.WriteLine();

            //Now we Unsubscribe The Subscriber2 From the event

            subscriber2.UnSubcribe(publisher);

            // This Part the News it will be send just to the First Subscriber Mohamed 


            publisher.PublisherNews("After UnSubscribe", "The News Now dosent send To youssef");


        }
    }
}

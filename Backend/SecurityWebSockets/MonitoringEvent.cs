namespace SecurityWebSockets
{
    public class MonitoringEvent
    {
        public Guid Id { get; set; }

        public DateTime OccurrenceTime { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public MonitoringEvent(string? description = null, string? imageUrl = null)
        {
            Description = description != null ? description : this.randomDescription();
            ImageUrl = imageUrl != null ? imageUrl: this.randomImage();
            Id = Guid.NewGuid();
            OccurrenceTime= DateTime.Now;
        }

        private string randomImage()
        {
            string[] images = {
                "https://gray-wmtv-prod.cdn.arcpublishing.com/resizer/XbMgjJqbm-e1soge2ZP3u_7xdlY=/1200x1800/smart/filters:quality(85)/cloudfront-us-east-1.images.arcpublishing.com/gray/RADKIPH2HBI6PANRYV72C5FANE.jpg",
                "https://www.briefcam.com/wp-content/uploads/2020/01/video-evidence-900.jpg",
                "https://i.ytimg.com/vi/kVe3e4WkEUM/maxresdefault.jpg",
                "https://www.denverpost.com/wp-content/uploads/2018/10/security-camera-footage.jpg?w=978",
                "https://www.safewise.com/app/uploads/2021/09/Nest-Cam-IQ-Outdoor-Night-Vision-768x432.jpg",
                "https://blog.camerasecuritynow.com/wp-content/uploads/2019/02/AdobeStock_227055662-1-1.jpg",
                "https://i.ytimg.com/vi/gEogsKVP_gM/maxresdefault.jpg",
                "https://cdn.thewirecutter.com/wp-content/uploads/2020/02/petcameratesting-lowres-2-3.jpg",
                "https://i.ytimg.com/vi/LcB_n4WMxxM/maxresdefault.jpg",
                "https://i.dailymail.co.uk/1s/2019/11/08/20/20779560-7666253-image-a-3_1573246444237.jpg",
                "https://www.rover.com/blog/wp-content/uploads/2019/09/ring-camera-catches-mountain-lion-footage.jpg",
                "https://i2-prod.cambridge-news.co.uk/incoming/article13789038.ece/ALTERNATES/s1200b/santaoutside.png",
            };

            Random rand = new Random();
            int index = rand.Next(images.Length);

            return images[index];
        }

        private string randomDescription()
        {
            string[] descriptions = {
                "Unexpected Activity: Back door was opened",
                "Arming Reminder: The System was not Armed when Ben's phone left Home",
                "Unexpected Activity: Ben is making food at 3am again",
                "Unexpected Activity: Bearded man entering through chimney",
                "Unexpected Activity: Unknown person detected on property",
                "Unexpected Activity: Unknown person detected on property"
            };

            Random rand = new Random();
            int index = rand.Next(descriptions.Length);

            return descriptions[index];
        }
    }
}

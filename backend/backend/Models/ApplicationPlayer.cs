using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace backend.Models
{
    public class ApplicationPlayer
    {
        public IList<PlayerDTO> data { get; set; }
        public MetadataDTO meta { get; set; }
        public IEnumerable<ApplicationPlayer> GetListDataPlayer(int? current_page)
        {
            //Set page or default=1 
            int page = current_page == null ? 1 : current_page.Value;
            List<ApplicationPlayer> application = new List<ApplicationPlayer>();
            MetadataDTO meta = new MetadataDTO();
            List<Player> list = new List<Player>();
            ///Get Data
            string ApiUrl = $"https://www.balldontlie.io/api/v1/players?per_page=25&page=" + current_page;
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {

                            string responseBody = objReader.ReadToEnd();
                            string jsonString = responseBody;
                            ApplicationPlayer? data =
                                JsonSerializer.Deserialize<ApplicationPlayer>(jsonString);
                            ////Transform PlayerDTO (JSON result) elements into Players (DB table)
                            foreach (PlayerDTO dataPlayer in data.data)
                            {
                                Player player = new Player();
                                player.Id = dataPlayer.id;
                                player.FirstName = dataPlayer.first_name;
                                player.LastName = dataPlayer.last_name;
                                player.Position = dataPlayer.position;
                                player.HeightFeet = dataPlayer.height_feet;
                                player.HeightInches = dataPlayer.height_inches;
                                player.WeightPounds = dataPlayer.weight_pounds;
                                list.Add(player);
                            }
                            ////Build ApplicationPlayer
                            ApplicationPlayer app = new ApplicationPlayer();
                            app.meta = data.meta;
                            app.data = data.data;
                            application.Add(app);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

            return application;
        }        
    } 
    
}

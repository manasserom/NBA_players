using System.Net;
using System.Text.Json;

namespace backend.Models
{
    public class AplicationDTO
    {
        public IList<PlayerDTO> data { get; set; }
        public MetadataDTO meta { get; set; }
        public IEnumerable<Player> GetListDataPlayer(int id)
        {
            //Set page or default=0 
            int page = 0;//current_page == null ? 0 : current_page.Value;
            int total_page = 1;
            List<Player> list = new List<Player>();
            //Iterar sobre el listado de jugadores
            ///Get Data
            for (int i = 1; i <= 1; i++)
            {
                string ApiUrl = $"https://www.balldontlie.io/api/v1/players?per_page=25&page=" + id;
                var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                //List<Application> lista = new List<Application>();
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {

                                //Crear clase Data que contenga la metadata y los teams
                                string responseBody = objReader.ReadToEnd();
                                string jsonString = responseBody;
                                AplicationDTO? data =
                                    JsonSerializer.Deserialize<AplicationDTO>(jsonString);
                                ////Add elements to list
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
                                    //player.TeamId = dataPlayer.team.id;
                                    list.Add(player);
                                }

                                ////Update top dimension
                                if (total_page != data.meta.total_pages)
                                    total_page = data.meta.total_pages;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle error
                }
            }

            return list;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStoreWithCore.Model
{
    public class VideoGameStoreModel : DbContext
    {
        //constructor that reads the db connection string
        public VideoGameStoreModel(DbContextOptions<VideoGameStoreModel> options): base(options)
        {

        }
        //grants the db class acess o the ablum model (auto generated in the web app)
        public DbSet<VideoGames> videoGames { get; set; }
        public DbSet<PlayerInfo> playerInfos { get; set; }
    }
}

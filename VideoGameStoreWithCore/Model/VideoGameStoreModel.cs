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
        //grants the db class acess to the video model (auto generated in the web app)
        public DbSet<VideoGames> VideoGameInfo { get; set; }
        public DbSet<PlayerInfo> PlayerInfo { get; set; }
    }
}

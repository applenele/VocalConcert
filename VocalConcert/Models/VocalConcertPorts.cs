using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeComb.Yuuko;
using CodeComb.Yuuko.Schema;

namespace VocalConcert.Models
{
    public class VocalConcertPorts : PortsContext
    {
        public VocalConcertPorts()
        {
            DB = new VocalConcertContext();
            TopAction = DB.Actions;
            TopMusic = DB.Musics;
            TopProduct = DB.Products;
        }

        #region Entity Framework 上下文
        [DbContext]
        public VocalConcertContext DB { get; set; }
        #endregion

        #region 数据源
        [Where("Type = 0 or Type = 1")]
        [OrderBy("Time desc")]
        [Take(10)]
        public DbSet<Music> TopMusic { get; set; }

        [OrderBy("Time desc")]
        [Take(10)]
        public DbSet<Action> TopAction { get; set; }

        [OrderBy("End desc")]
        [Take(10)]
        public DbSet<Product> TopProduct { get; set; }
        #endregion

        #region Ports
        [CollectionPort]
        [Binding("TopMusic")]
        public List<Music> TopMusicPort { get; set; }

        [CollectionPort]
        [Binding("TopProduct")]
        public List<Product> TopProductPort { get; set; }

        [CollectionPort]
        [Binding("TopAction")]
        public List<Action> TopActionPort { get; set; }
        #endregion
    }
}
﻿using System.Collections.Generic;

namespace BeezyTest.BeezyCinemaDb.Models.BeezyCinema
{
    public partial class Room
    {
        public Room()
        {
            Session = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Seats { get; set; }
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}

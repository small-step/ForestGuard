using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestGuard
{
    public class User
    {
        public static uint Id { get; set; }
        public static string Nickname { get; set; }
        public static uint RoomId { get; set; } = 0;
        public static uint SeatId { get; set; } = 0;
    }
}

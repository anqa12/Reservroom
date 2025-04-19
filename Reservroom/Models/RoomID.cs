using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservroom.Models
{
    public class RoomID
    {
        public int FloorNum { get; }
        public int RoomNum { get; }

        public RoomID(int floorNum, int roomNum)
        {
            FloorNum = floorNum;
            RoomNum = roomNum;
        }

        public override string ToString()
        {
            return $"Floor: {FloorNum}, Room: {RoomNum}";
        }

        public override bool Equals(object? obj)
        {
            return obj is RoomID roomID &&
                   FloorNum == roomID.FloorNum &&
                   RoomNum == roomID.RoomNum;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNum, RoomNum);
        }
        public static bool operator ==(RoomID left, RoomID right)
        {
            if(left is null && right is null)
            {
                return true;
            }
            return !(left is null) && left.Equals(right);
        }
        public static bool operator !=(RoomID left, RoomID right)
        {
            return !(left == right);
        }
    }
}

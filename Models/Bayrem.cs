using BotFactory.Interface;
using System;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class Zeineb : WorkingUnit, IT_800, ITestingUnit
    {

        public new string Name { get; set; }
        public Zeineb() : base(10, 3)
        {
            Name = "Zeineb";
        }
        public override async Task<bool> WorkBegins()
        {
            OnStatusChanged(new StatusChangedEventArgs("le Robot se deplace vers son lieux de travail"));
            bool result = await Move(this.CurrentPos, this.WorkingPos);
            this.IsWorking = true;
            CurrentPos.x = WorkingPos.x;
            CurrentPos.y = WorkingPos.y;
            return result;

        }



        public override async Task<bool> WorkEnds()
        {
            OnStatusChanged(new StatusChangedEventArgs("le Robot se deplace vers sa position de stationnement"));
            bool result = await Move(this.CurrentPos, this.ParkingPos);
            this.IsWorking = false;
            CurrentPos.x = ParkingPos.x;
            CurrentPos.y = ParkingPos.y;
            return result;
        }


    }
}

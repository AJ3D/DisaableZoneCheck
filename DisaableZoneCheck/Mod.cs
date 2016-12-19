using ICities;
using UnityEngine;


namespace DisableZoneCheck
{

    public class DisableZoneCheckMod : IUserMod
    {
        public string Name
        {
            get
            {
                return "Disable ZoneCheck";
            }
        }
        public string Description
        {
            get
            {
                return "Disables ZoneCheck on Growable Buildings";
            }
        }
    }
}
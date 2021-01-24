using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Activities
{
    class ActivitiesList
    {
        private List<SingleActivity> _listOfActivities;

        public ActivitiesList(List<SingleActivity> listOfActivities)
        {
            _listOfActivities = listOfActivities;
        }

    }
}

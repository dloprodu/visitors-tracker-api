using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorsTracker.Models
{
    /**
     * Guest interace
     **/
    public interface IGuest
    {
        /**
         * User IP
         */
        public string IP { get; set; }

        /**
         * Last visit date.
         */
        public string LastVisit { get; set; }

        /**
         * Visit counter.
         */
        public int Visits { get; set; }

        /**
         * IP type.
         */
        public string IPType { get; set; }

        /*
         * User agent (ie, edge, crhrome, firefox, safari, other).
         */
        public string UserAgent { get; set; }

        /**
         * Platoform (desktop, ios, android).
         */
        public string Platform { get; set; }

        /**
         * Language ISO code
         */
        public string Language { get; set; }

        /**
         * Country ISO code
         */
        public string Country { get; set; }

        /**
         * Continent ISO code
         */
        public string Continent { get; set; }

        /**
         * Region ISO code
         */
        public string Region { get; set; }
    }
}

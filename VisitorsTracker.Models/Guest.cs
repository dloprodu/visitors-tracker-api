using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VisitorsTracker.Models
{
    /**
     * Collects all the information to be tracked.
     */
    public class Guest
    {
        /**
         * Unique ID.
         */
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [BsonIgnoreIfNull]
        public string Id { get; set; }

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
         * Country name
         */
        public string CountryName { get; set; }

        /**
         * Continent ISO code
         */
        public string Continent { get; set; }

        /**
         * Continent name
         */
        public string ContinentName { get; set; }

        /**
         * Region ISO code
         */
        public string Region { get; set; }

        /**
         * Region name
         */
        public string RegionName { get; set; }
    }
}

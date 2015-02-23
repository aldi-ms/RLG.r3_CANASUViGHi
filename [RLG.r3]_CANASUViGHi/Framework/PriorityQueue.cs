using RLG.R3_CANASUViGHi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RLG.R3_CANASUViGHi.Framework
{
    internal class PriorityQueue<T>
        where T : IActor
    {
        private List<T> actorList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue" /> class.
        /// </summary>
        public PriorityQueue()
        {
            this.actorList = new List<T>();
        }

        /// <summary>
        /// Add an Actor the the PriorityQueue.
        /// </summary>
        /// <param name="actor">The Actor to add.</param>
        internal void AddActor(T actor)
        {
            this.actorList.Add(actor);

            SortList();
        }

        /// <summary>
        /// Remove an Actor by reference.
        /// </summary>
        /// <param name="actor">The Actor to remove.</param>
        /// <returns>True if the Actor is successfully removed; otherwise false.
        /// <remarks>This method also returns false if the Actor was not found in the PriorityQueue.</remarks></returns>
        internal bool RemoveActor(T actor)
        {
            if (this.actorList.Remove(actor))
            {
                SortList();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sums all Actors' energy by their speed.
        /// </summary>
        /// <remarks>Call each turn to make Actors accumulate energy.</remarks>
        internal void AccumulateEnergy()
        {
            foreach (T actor in actorList)
            {
                actor.Energy += actor.Speed;
            }

            SortList();
        }

        private void SortList()
        {
            actorList.Sort((x, y) => y.Energy.CompareTo(x.Energy));
        }
    }
}

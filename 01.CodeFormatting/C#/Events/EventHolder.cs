namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> eventByTitle = new MultiDictionary<string, Event>(true);

        private OrderedBag<Event> eventByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.eventByTitle.Add(title.ToLower(), newEvent);
            this.eventByDate.Add(newEvent);
            Events.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.eventByTitle[title])
            {
                removed++;
                this.eventByDate.Remove(eventToRemove);
            }

            this.eventByTitle.Remove(title);
            Events.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.eventByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Events.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Events.NoEventsFound();
            }
        }
    }
}

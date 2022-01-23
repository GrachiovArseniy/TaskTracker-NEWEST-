using System;
using System.Collections.Generic;
using TaskTrecker.Model;

namespace Extentions
{
    public static class Extentions
    {
        public static string GetString(this TaskStatus taskStatus)
        {
            switch (taskStatus)
            {
                case TaskStatus.Backlog:
                    return "Backlog";
                case TaskStatus.Appointed:
                    return "Appointed";
                case TaskStatus.InProgress:
                    return "In progress";
                case TaskStatus.UnderReview:
                    return "Under review";
                case TaskStatus.Accepted:
                    return "Accepted";
                case TaskStatus.NotAccepred:
                    return "Not accepted";
                default:
                    return "ERROR";
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="newObj">Used for created new element</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindOrCreate<T>(this List<T> list, T newObj, Func<T, bool> predicate)
        {
            foreach (T t in list)
            {
                if (predicate.Invoke(t))
                {
                    return t;
                }
            }

            list.Add(newObj);
            return newObj;
        }
    }
}

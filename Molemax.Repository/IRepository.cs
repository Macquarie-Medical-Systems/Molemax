using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository
{
    public interface IRepository<T> where T:class
    {
        DbSet<T> Table { get; }
        /// <summary>
        /// Returns all items. 
        /// </summary>
        IEnumerable<T> Get();

        /// <summary>
        /// Returns the item with the given id. 
        /// </summary>
        T Get(int id);

        /// <summary>
        /// Adds a new item if the item does not exist, updates the 
        /// existing item otherwise.
        /// </summary>
        T Upsert(T item);

        /// <summary>
        /// Adds  new items if items do not exist, updates the 
        /// existing items otherwise.
        /// </summary>
        IEnumerable<T> Upsert(IEnumerable<T> item);

        /// <summary>
        /// Deletes a item.
        /// </summary>
        void Delete(int id);
    }
}

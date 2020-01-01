using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BE;

namespace DAL
{

    public interface IDAL
    {
        /// <summary>
        /// add a guest requests
        /// </summary>
        /// <param name="GR">the Guest request</param>
        void AddGuestRequest(BE.GuestRequest GR);

        /// <summary>
        /// update a guest requests
        /// </summary>
        /// <param name="GR">the Guest request</param>
        void UpdateGuestRequest(DemandStatusTypes status, int key);

        /// <summary>
        /// add a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
        void AddHostingUnit(BE.HostingUnit HU);

        /// <summary>
        /// delete a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
        void DelHostingUnit(BE.HostingUnit HU);

        /// <summary>
        /// update a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
        void UpdateHostingUnit(BE.HostingUnit HU);

        /// <summary>
        /// add an order
        /// </summary>
        /// <param name="O">order</param>
        void AddOrder(BE.Order O);

        /// <summary>
        /// update an order usually the order status is updated
        /// </summary>
        /// <param name="O">order</param>
        void UpdateOrder(OrderStatusTypes status, int key);



        //get data
        IEnumerable<BE.HostingUnit> GetHostingUnits();
        IEnumerable<BE.GuestRequest> GetGuestRequests();
        IEnumerable<BE.Order> GetOrders();
        IEnumerable<string> GetBankBranches();
    }

 

    /// <summary>
    /// static class that does deep copy
    /// </summary>
    public static class Cloning
    {
        public static T Copy<T>(this T source)
        {
            var isNotSerializable = !typeof(T).IsSerializable;
            if (isNotSerializable)
                throw new ArgumentException("The type must be serializable.", "source");

            var sourceIsNull = ReferenceEquals(source, null);
            if (sourceIsNull)
                return default(T);

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    /// <summary>
    /// factory class
    /// </summary>
    public class FactoryDal
    {
        public static IDAL GetDal()
        {
            return Dal_imp.Instance;
        }
    }
}

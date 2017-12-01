using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalRHub.Models;
using SignalRHub.Repository;

namespace SignalRHub.Services
{
    public partial class CustomerService
    {
        private GenericRepository<Customer> CustRepository;

        //CustomerRepository CustRepository;
        public CustomerService()
        {
            this.CustRepository = new GenericRepository<Customer>(new dbDevEntities());
        }

        public IEnumerable<Customer> GetAll(object[] parameters)
        {
            string spQuery = "[Get_Customer] {0}";
            return CustRepository.ExecuteQuery(spQuery, parameters);
        }

        public Customer GetbyID(object[] parameters)
        {
            string spQuery = "[Get_CustomerbyID] {0}";
            return CustRepository.ExecuteQuerySingle(spQuery, parameters);
        }

        public int Insert(object[] parameters)
        {
            string spQuery = "[Set_Customer] {0}, {1}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }

        public int Update(object[] parameters)
        {
            string spQuery = "[Update_Customer] {0}, {1}, {2}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }

        public int Delete(object[] parameters)
        {
            string spQuery = "[Delete_Customer] {0}";
            return CustRepository.ExecuteCommand(spQuery, parameters);
        }
    }
}
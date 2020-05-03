﻿using System.Threading.Tasks;
using WebStore.DB.Models;

namespace WebStore.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<OrderInfo> OrderGetById(int orderId);
        ValueTask<OrderInfo> OrderInser(OrderInfo order);

        void TransactionStart();
        void TransactionCommit();
        void TransactioRollBack();
    }
}
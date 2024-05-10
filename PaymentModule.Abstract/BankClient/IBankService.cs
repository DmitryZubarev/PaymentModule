using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.BankClient
{
    public interface IBankService
    {
        //регистрация заказа в системе банка для первого платежа
        //Вернётся окно заполнения реквизитов и ид заказа в банке
        public OrderRegisterResponse StartFirstPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow);

        //Запрос результатов проведения первого платежа
        //вернётся id связки (client, shop) и сам статус
        public PaymentStatus GetFirstPaymentOrderStatus(int orderId);

        //Регистрация автоплатежа
        //Вернётся уникальный id заказа в платёжной системе
        public int StartAutoPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow);

        //Запрос оплаты
        public void DoAutoPayment(int shopOrderId, int bindingId);

        //Получение результата автоплатежа
        //Вернётся статус заказа
        public bool GetAutoPaymentOrderStatus(int bankOrderId);
    }
}

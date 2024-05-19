using PaymentModule.Abstract.BankClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule.Abstract.BusinessLogic
{
    public interface ISharingSessionService
    {
        //регистрация заказа в системе банка для первого платежа
        //Вернётся окно заполнения реквизитов и ид заказа в банке
        public OrderRegisterResponse StartFirstPayment(int clientId, int shopOrderId, int sum, Uri returnShopWindow);

        //Запрос результатов проведения первого платежа
        //вернётся id связки (client, shop) и сам статус
        public PaymentStatus GetFirstPaymentOrderStatus(int orderId);

        //Регистрация автоплатежа -> Запрос оплаты -> Получение результата автоплатежа
        //Вернётся статус заказа
        public void StartAutoPayment(int clientId, int shopOrderId, int tariffId, Uri returnShopWindow, int bindingId);

        public void EndSession(int shopOrderId);
    }
}

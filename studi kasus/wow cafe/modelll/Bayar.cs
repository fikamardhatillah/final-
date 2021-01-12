using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Model
{
    class Bayar
    {
        OnPaymentChangedListener paymentListener;
        public Bayar(OnPaymentChangedListener paymentListener)
        {

            this.paymentListener = paymentListener;
        }

        public void updateTotal(double subTotal, double promo)
        {

            double total = subTotal - promo;
            this.paymentListener.onPriceUpdated(subTotal, total, promo);

        }
    }

    interface OnPaymentChangedListener
    {
        void onPriceUpdated(double subtTotal, double total, double promo);

    }
}



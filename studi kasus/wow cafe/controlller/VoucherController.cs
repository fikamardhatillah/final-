using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Model;

namespace Cafe.Controller
{
    class VoucherController
    {
        public List<Diskon> diskon;

        public VoucherController()
        {
            diskon = new List<Diskon>();
        }

        public void addPromo(Diskon diskon)
        {
            this.diskon.Add(diskon);
        }

        public List<Diskon> getDiskon()
        {
            return this.diskon;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prominence.Model.Interfaces
{
    public interface IInterstitialAd
    {
        Task Display(string adId);
    }
}

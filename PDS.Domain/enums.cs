using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    [Flags]
    public enum StateCovers
    {
        None = 0,
        NSW = 1,
        QLD = 2,
        SA = 4,
        TAS = 8,
        VIC = 16,
        WA = 32,
        ACT = 64,
        NT = 128
    }

    public enum Waviers
    {
        None = 0,
        Excess = 1,
        Copayment = 2
    }

    public enum SalesChannels
    {
        None = 0,
        ContactCentre = 1,
        Online = 2,
        Aggregators = 4
    }

    public enum Scales
    {
        None = 0,
        Single = 1,
        Couple = 2,
        Family = 4,
        SingleParentFamily = 8
    }

    public enum ScaleQuoteMaps
    {
        None = 0,
        SingleToSingle = 1,
        CoupleToCouple = 2,
        CoupleToFamily = 4,
        FamilyToCouple = 8,
        FamilyToFamily = 16,
        SingleParentFamilyToCouple = 32,
        SingleParentFamilyToFamily = 64,
        SingleParentFamilyToSingleParentFamily = 128
    }
}

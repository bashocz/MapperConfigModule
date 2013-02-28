using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum ProcessEvent
    {
        [EnumDescription("No action in progress")]
        NoAction = 0,
        [EnumDescription("Process started")]
        ProcessStarted,
        [EnumDescription("Process ended")]
        ProcessEnded,
        [EnumDescription("Probing started")]
        ProbingStarted,
        [EnumDescription("Probing ended")]
        ProbingEnded,
        [EnumDescription("Reprobing started")]
        ReprobingStarted,
        [EnumDescription("Reprobing ended")]
        ReprobingEnded,
        [EnumDescription("Inking started")]
        InkingStarted,
        [EnumDescription("Inking ended")]
        InkingEnded,
        [EnumDescription("Map editing started")]
        MapEditingStarted,
        [EnumDescription("Map editing ended")]
        MapEditingEnded,
        [EnumDescription("Lot loading")]
        LotLoading,
        [EnumDescription("Lot loaded")]
        LotLoaded,
        [EnumDescription("Lot starting")]
        LotStarting,
        [EnumDescription("Lot started")]
        LotStarted,
        [EnumDescription("Lot ending")]
        LotEnding,
        [EnumDescription("Lot ended")]
        LotEnded,
        [EnumDescription("Wafer loading")]
        WaferLoading,
        [EnumDescription("Wafer loaded")]
        WaferLoaded,
        [EnumDescription("Wafer unloading")]
        WaferUnloading,
        [EnumDescription("Wafer unloaded")]
        WaferUnloaded,
        [EnumDescription("Wafer starting")]
        WaferStarting,
        [EnumDescription("Wafer started")]
        WaferStarted,
        [EnumDescription("Wafer ending")]
        WaferEnding,
        [EnumDescription("Wafer ended")]
        WaferEnded,
        [EnumDescription("Wafer restarting")]
        WaferRestarting,
        [EnumDescription("Wafer restarted")]
        WaferRestarted,
        [EnumDescription("Wafer retesting")]
        WaferRetesting,
        [EnumDescription("Wafer retested")]
        WaferRetested,
        [EnumDescription("Moving to die")]
        MovingTo,
        [EnumDescription("Moved to die")]
        MovedTo,
        [EnumDescription("Die contacting")]
        Contacting,
        [EnumDescription("Die contacted")]
        Contacted,
        [EnumDescription("Die uncontacting")]
        Uncontacting,
        [EnumDescription("Die uncontacted")]
        Uncontacted,
        [EnumDescription("Die recontacting")]
        Recontacting,
        [EnumDescription("Die recontacted")]
        Recontacted,
        [EnumDescription("Die probing")]
        DieProbing,
        [EnumDescription("Die probed")]
        DieProbed,
        [EnumDescription("Die inking")]
        DieInking,
        [EnumDescription("Die inked")]
        DieInked,
        [EnumDescription("Statistic calculating")]
        StatisticCalculating,
        [EnumDescription("Statistic calculated")]
        StatisticCalculated,

        [EnumDescription("Process paused")]
        ProcessPaused,
        [EnumDescription("Process continued")]
        ProcessContinued,
        [EnumDescription("Process stopping")]
        ProcessStopping,
        [EnumDescription("Process aborting")]
        ProcessAborting,

        [EnumDescription("Partial secs saved to local")]
        LocalPartialSecsSaved,
        [EnumDescription("Full secs saved to local")]
        LocalFullSecsSaved,
        [EnumDescription("Partial secs saved to unsent")]
        UnsentPartialSecsSaved,
        [EnumDescription("Full secs saved to unsent")]
        UnsentFullSecsSaved,
        [EnumDescription("Partial wmxml saved to local")]
        LocalPartialWmxmlSaved,
        [EnumDescription("Full wmxml saved to local")]
        LocalFullWmxmlSaved,
        [EnumDescription("Partial wmxml saved to unsent")]
        UnsentPartialWmxmlSaved,
        [EnumDescription("Full wmxml saved to unsent")]
        UnsentFullWmxmlSaved,
        [EnumDescription("Partial wmxml saved to unsent for web service")]
        UnsentWsPartialWmxmlSaved,
        [EnumDescription("Full wmxml saved to unsent for web service")]
        UnsentWsFullWmxmlSaved,
        [EnumDescription("Complete wmxml saved to local")]
        ExternalWmxmlSaved,
        [EnumDescription("Complete wmxml saved to newton")]
        NewtonWmxmlSaved,

        [EnumDescription("Selected die changed")]
        SelectedDieChanged,

        [EnumDescription("Manual start of test finished")]
        ManualSotFinished,

        [EnumDescription("Dialog shown")]
        DialogShown,
        [EnumDescription("Dialog closed")]
        DialogClosed,
        [EnumDescription("Checkin was started after press next button at 1. checkin page")]
        CheckinStarted,
        [EnumDescription("Checkin was finished after press upload button at last checkin page")]
        CheckinFinished,
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public enum OVERLAY_MODE
    {
        OVL_NOT_DEFINED = -1,
        OVL_LIVE_VIDEO = 0,
        OVL_COMPARE = 1,
        OVL_OVERLAY = 2,
        OVL_SEGMENTATION_OVERLAY = 3
    }

    public enum SHEET_DISPLAY_MODE
    {
        DISP_33,
        DISP_MC,
        DISP_DUMMY
    }

    public enum IMAGING_SOURCES_INDEX
    {
        SOURCE_LIVEVIDEO,
        SOURCE_LIVEIMAGE,
        SOURCE_FILEIMPORT,
        SOURCE_EXTERN1
    }

    public enum GENDER
    {
        M,
        F
    }

    public enum TOTAL_NEVI_COUNT
    {
        UNKNOWN,
        LESSTHAN_20,
        GREATERTHAN_EQUALTO_20
    }

    public enum FRECKLE_INDEX
    {
        UNKNOWN,
        NONE,
        SOME
    }

    public enum ATYPICAL_NEVI_COUNT
    {
        UNKNOWN,
        ATYPICAL_0,
        ATYPICAL_1_TO_2,
        ATYPICAL_GREATERTHAN_3
    }

    public enum EPISODES_OF_SUNBURN
    {
        UNKNOWN,
        EPISODES_0,
        EPISODES_1_TO_2,
        EPISODES_GREATERTHAN_3
    }

    public enum KIND_ENUM
    {
        KIND_UNDEFINED = 0,
        KIND_MAKRO = 1,
        KIND_MIKRO = 2,
        KIND_CLOSEUP = 3,
        KIND_HISTOPAT = 4,
        KIND_COSMAX = 5
    }

    public enum REPORT_VISIT_OPTION
    {
        ALL_VISITS,
        SELECT_VISITS,
        SELECT_INDIVIDUAL
    }
}

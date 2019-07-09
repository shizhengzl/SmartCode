using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum AuditStatus
    {
        [Description("待审核")]
        WaitingAudit = 1,
        [Description("已审核")]
        Audited = 2,
        [Description("驳回")]
        Reject = 3
    }
}

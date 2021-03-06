using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class NotificationListResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public int totalNotifications { get; set; }
        public List<MobileNotificationSamples> damagedSamples { get; set; }
        public List<MobileNotificationSamples> timeoutExpirySamples { get; set; }
        public List<MobilePositiveSubjects> positiveSubjects { get; set; }
        public List<CHCSubjectResigration> chcSubjectResigrations { get; set; }
        public List<SampleCollection> chcSampleCollections { get; set; }
        public List<TestResult> results { get; set; }
        public List<MobilePNDTReferral> pndtReferral { get; set; }
        public List<MobileMTPReferral> mtpReferral { get; set; }
        public List<MobilePrePNDTCounselling> prePndtCounselling { get; set; }
        public List<MobilePNDTesting> pndtTesting { get; set; }
        public List<MobilePostPNDTCounselling> postPndtCounselling { get; set; }
        public List<MobileMTPService> mtpService { get; set; }
        public List<ANMMobileMTPFollowups> postMtpFollowUp { get; set; }
        public List<MobileMenus> leftSideMenus { get; set; }
        public MobileAlert alert { get; set; }
    }


    public class MobileMenus
    {
        public string name { get; set; }
        public string link { get; set; }
        public string odiyaName { get; set; }
    }

    public class ANMMobileMTPFollowups
    {

        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public string mtpDateTime { get; set; }
        public string obstetricianName { get; set; }
        public MTPFirstFollowup firstFollowUp { get; set; }
        public MTPSecondFollowup secondFollowUp { get; set; }
        public MTPThirdFollowup thirdFollowUp { get; set; }
    }

    public class CHCSubjectResigration
    {
        public SubjectPrimary PrimaryDetail { get; set; }
        public SubjectAddress AddressDetail { get; set; }
        public SubjectPregnancy PregnancyDetail { get; set; }
        public SubjectParent ParentDetail { get; set; }
        public TestResult Results { get; set; }
    }

    public class MobilePNDTReferral
    {
        public MobilePNDTSubject subject { get; set; }
        public MobilePNDTSpouse spouse { get; set; }
        public NotificationPrePNDTCounselling prePndtCounselling { get; set; }
        public NotificationPNDTesting pndtTesting { get; set; }
    }

    public class MobileMTPReferral
    {
        public MobileMTPSubject subject { get; set; }
        public MobileMTPSpouse spouse { get; set; }
        public NotificationPostPNDTCounselling postPndtCounselling { get; set; }
        public NotificationMTPService mtpService { get; set; }
    }
}

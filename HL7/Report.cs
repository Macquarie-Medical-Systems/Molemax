using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7
{
    class Report
    {
        public static void GenerateHL7(string inputPdfFile, string outputHL7File, string patientFirstname, string patientLastname, DateTime patientDob, string doctorFirstname, string doctorLastname)
        {
            Byte[] bytes = File.ReadAllBytes(inputPdfFile);
            String file = Convert.ToBase64String(bytes);

            Message message = new Message();
            message.AddSegmentMSH("MoleMax", "MoleMax", "PMS", "PMS", "", "ORU^R01", "123420181006181311", "P", "2.3");

            Segment segmentPID = new Segment("PID", new HL7Encoding());
            segmentPID.AddNewField("1", 1);
            segmentPID.AddNewField("^^^^MR~203272^^^CMS^PI~25653450431^^^AUSHIC^MC", 3);
            segmentPID.AddNewField(patientLastname + "^" + patientFirstname + "", 5);
            segmentPID.AddNewField(patientDob.ToString("yyyyMMdd"), 7);
            message.AddNewSegment(segmentPID);

            Segment segmentOBR = new Segment("OBR", new HL7Encoding());
            segmentOBR.AddNewField("1", 1);
            segmentOBR.AddNewField("N215^SKIN CHECK^CMS", 4);
            segmentOBR.AddNewField(DateTime.Now.ToString("yyyyMMdd") + "0000+1100", 7);
            segmentOBR.AddNewField("F", 25);
            segmentOBR.AddNewField("^^^" + DateTime.Now.ToString("yyyyMMdd") + "0000+1100^^", 27);
            message.AddNewSegment(segmentOBR);

            Segment segment = new Segment("OBX", new HL7Encoding());
            segment.AddNewField("6", 1);
            segment.AddNewField("ED", 2);
            segment.AddNewField("PDF^Display in PDF Format^AUSPDI", 3);
            segment.AddNewField("MERIDIAN&MERIDIAN:3.1.2[win32-i386]&L^AP^PDF^Base64^" + file, 5);
            message.AddNewSegment(segment);

            System.IO.File.WriteAllText(outputHL7File, message.SerializeMessage(false));
        }
    }
}

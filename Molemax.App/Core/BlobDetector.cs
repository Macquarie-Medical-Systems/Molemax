using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;

namespace Molemax.App.Core
{
    public class BlobDetector
    {
        public void AutoSegmantation(string sImportImage, string sExportImage, double dThreshold)
        {
            int NumberOfLinesOrVertices = 4;
            double[] InfiniteLines = { 0.0, -1.0, -1.0, 1.0 };
            double[] InfiniteLines0 = { -1.0, 0.0, -1.0, -1.0 };
            double[] InfiniteLines1 = { 0.0, 1.0, 1.0, -1.0 };
            double[] InfiniteLines2 = { 1.0, 0.0, 1.0, 1.0 };

            MIL_ID MilApplication = MIL.M_NULL;
            double AxisPrincipalAngle = 0.0;
            double CenterOfGravityX = 0.0;
            double CenterOfGravityY = 0.0;
            double AxisSecondaryAngle = 0.0;
            MIL_ID MilSystem = MIL.M_NULL;
            MIL_ID OrginalImage = MIL.M_NULL;
            MIL_ID MimConvertdestination = MIL.M_NULL;
            MIL_ID MimOpendestination = MIL.M_NULL;
            MIL_ID MimBinarizedestination = MIL.M_NULL;
            MIL_ID MimOpendestination2 = MIL.M_NULL;
            MIL_ID BlobContext = MIL.M_NULL;
            MIL_ID BlobResult = MIL.M_NULL;
            MIL_ID DestinationImage = MIL.M_NULL;
            MIL_ID GraphicsContext = MIL.M_NULL;
            MIL_ID GraphicsContext2 = MIL.M_NULL;

            MIL.MappAlloc(MIL.M_NULL, MIL.M_DEFAULT, ref MilApplication);
            MIL.MsysAlloc(MIL.M_DEFAULT, "M_SYSTEM_HOST", MIL.M_DEFAULT, MIL.M_DEFAULT, ref MilSystem);
            MIL.MbufImport(sImportImage, MIL.M_DEFAULT, MIL.M_RESTORE + MIL.M_NO_GRAB + MIL.M_NO_COMPRESS, MilSystem, ref OrginalImage);
            MIL.MbufAllocColor(MilSystem, 1, 1872, 1053, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, ref MimConvertdestination);
            MIL.MbufClone(MimConvertdestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimOpendestination);
            MIL.MbufClone(MimOpendestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimBinarizedestination);
            MIL.MbufClone(MimBinarizedestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimOpendestination2);
            MIL.MbufClone(OrginalImage, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref DestinationImage);

            // Post-Alloc Block for ELM COPY
            MIL.MbufClear(DestinationImage, MIL.M_COLOR_BLACK);

            MIL.MblobAlloc(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobContext);

            // Control Block for Blob Context
            MIL.MblobControl(BlobContext, MIL.M_BLOB_CONTRAST, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_BREADTH, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CENTER_OF_GRAVITY + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CENTER_OF_GRAVITY + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_COMPACTNESS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONTACT_POINTS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONVEX_HULL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONVEX_PERIMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_EULER_NUMBER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_PRINCIPAL_AXIS_ANGLE + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_PRINCIPAL_AXIS_ANGLE + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_SECONDARY_AXIS_ANGLE + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_SECONDARY_AXIS_ANGLE + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_CONTACT_POINTS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_GENERAL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_MAX_DIAMETER_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_MIN_DIAMETER_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PERPENDICULAR_TO_MAX_DIAMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PERPENDICULAR_TO_MIN_DIAMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PRINCIPAL_AXIS_ELONGATION + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PRINCIPAL_AXIS_ELONGATION + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERETS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_INTERCEPT, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_LENGTH, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MAX_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MEAN_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_AREA_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_PERIMETER_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_FIRST_ORDER + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_FIRST_ORDER + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_GENERAL + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_GENERAL + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_SECOND_ORDER + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_SECOND_ORDER + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_NUMBER_OF_HOLES, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_PERIMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_RECTANGULARITY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_ROUGHNESS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_RUNS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SIGMA_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SUM_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SUM_PIXEL_SQUARED, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_WORLD_BOX, MIL.M_ENABLE);

            MIL.MblobAllocResult(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobResult);

            MIL.MimConvert(OrginalImage, MimConvertdestination, MIL.M_RGB_TO_L);
            MIL.MimOpen(MimConvertdestination, MimOpendestination, 3, MIL.M_GRAYSCALE);
            MIL.MimBinarize(MimOpendestination, MimBinarizedestination, MIL.M_FIXED + MIL.M_LESS_OR_EQUAL, dThreshold, MIL.M_NULL);
            MIL.MimOpen(MimBinarizedestination, MimOpendestination2, 4, MIL.M_GRAYSCALE);
            MIL.MblobCalculate(BlobContext, MimOpendestination2, MIL.M_NULL, BlobResult);
            MIL.MblobSelect(BlobResult, MIL.M_INCLUDE_ONLY, MIL.M_AREA, MIL.M_GREATER, 10000.0, MIL.M_NULL);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_AXIS_PRINCIPAL_ANGLE + MIL.M_BINARY, ref AxisPrincipalAngle);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_CENTER_OF_GRAVITY_X + MIL.M_BINARY, ref CenterOfGravityX);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_CENTER_OF_GRAVITY_Y + MIL.M_BINARY, ref CenterOfGravityY);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_AXIS_SECONDARY_ANGLE + MIL.M_BINARY, ref AxisSecondaryAngle);
            MIL.MbufCopy(OrginalImage, DestinationImage);
            MIL.McalUniform(DestinationImage, 0.0, 0.0, 1.0, 1.0, 0.0, MIL.M_DEFAULT);
            MIL.McalFixture(DestinationImage, MIL.M_NULL, MIL.M_MOVE_RELATIVE, MIL.M_POINT_AND_ANGLE, DestinationImage, CenterOfGravityX, CenterOfGravityY, AxisPrincipalAngle, MIL.M_DEFAULT);
            MIL.MgraAlloc(MilSystem, ref GraphicsContext);
            MIL.MgraColor(GraphicsContext, MIL.M_RGB888(255, 0, 0));
            MIL.MgraControl(GraphicsContext, MIL.M_INPUT_UNITS, MIL.M_WORLD);
            MIL.MgraControl(GraphicsContext, MIL.M_COLOR, MIL.M_COLOR_GREEN);
            MIL.MgraLines(GraphicsContext, DestinationImage, NumberOfLinesOrVertices, InfiniteLines, InfiniteLines0, InfiniteLines1, InfiniteLines2, MIL.M_INFINITE_LINES);
            MIL.MgraAlloc(MilSystem, ref GraphicsContext2);
            MIL.MblobDraw(GraphicsContext2, BlobResult, DestinationImage, MIL.M_DRAW_BLOBS_CONTOUR + MIL.M_DRAW_CENTER_OF_GRAVITY, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT);
            MIL.MbufSave(sExportImage, DestinationImage);

            MIL.MgraFree(GraphicsContext2);
            MIL.MgraFree(GraphicsContext);
            MIL.MblobFree(BlobResult);
            MIL.MblobFree(BlobContext);
            MIL.MbufFree(DestinationImage);
            MIL.MbufFree(MimOpendestination2);
            MIL.MbufFree(MimBinarizedestination);
            MIL.MbufFree(MimOpendestination);
            MIL.MbufFree(MimConvertdestination);
            MIL.MbufFree(OrginalImage);
            MIL.MsysFree(MilSystem);
            MIL.MappFree(MilApplication);
        }

        public void ManualSegmantation(string[] args)
        {
            int NumberOfLinesOrVertices = 7;
            int NumberOfLinesOrVertices0 = 4;
            double[] Polygon = { 100.0, 120.0, 150.0, 110.0, 70.0, 50.0, 60.0 };
            double[] Polygon0 = { 40.0, 50.0, 70.0, 100.0, 90.0, 60.0, 45.0 };
            double[] InfiniteLines = { 0.0, -1.0, -1.0, 1.0 };
            double[] InfiniteLines0 = { -1.0, 0.0, -1.0, -1.0 };
            double[] InfiniteLines1 = { 0.0, 1.0, 1.0, -1.0 };
            double[] InfiniteLines2 = { 0.0, 0.0, 1.0, 1.0 };

            string IMAGE_FILE = @"C:\Users\Admin\Desktop\Test Images\ELM_18_70.jpg";

            MIL_ID MilApplication = MIL.M_NULL;
            double AxisPrincipalAngle = 0.0;
            double AxisSecondaryAngle = 0.0;
            double CenterOfGravityX = 0.0;
            double CenterOfGravityY = 0.0;
            MIL_ID MilSystem = MIL.M_NULL;
            MIL_ID ELM_18_70 = MIL.M_NULL;
            MIL_ID ELMCopy = MIL.M_NULL;
            MIL_ID GraphicsContext = MIL.M_NULL;
            MIL_ID MimConvertdestination = MIL.M_NULL;
            MIL_ID MimBinarizedestination = MIL.M_NULL;
            MIL_ID BlobContext = MIL.M_NULL;
            MIL_ID BlobResult = MIL.M_NULL;
            MIL_ID ELMCopy2 = MIL.M_NULL;
            MIL_ID GraphicsContext2 = MIL.M_NULL;
            MIL_ID GraphicsContext3 = MIL.M_NULL;

            MIL.MappAlloc(MIL.M_NULL, MIL.M_DEFAULT, ref MilApplication);
            MIL.MsysAlloc(MIL.M_DEFAULT, "M_SYSTEM_HOST", MIL.M_DEFAULT, MIL.M_DEFAULT, ref MilSystem);
            MIL.MbufImport(IMAGE_FILE, MIL.M_DEFAULT, MIL.M_RESTORE + MIL.M_NO_GRAB + MIL.M_NO_COMPRESS, MilSystem, ref ELM_18_70);
            MIL.MbufClone(ELM_18_70, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref ELMCopy);

            // Post-Alloc Block for ELM Copy
            MIL.MbufClear(ELMCopy, MIL.M_COLOR_BLACK);

            MIL.MbufAllocColor(MilSystem, 1, 1872, 1053, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, ref MimConvertdestination);
            MIL.MbufClone(MimConvertdestination, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MimBinarizedestination);
            MIL.MbufClone(ELM_18_70, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, ref ELMCopy2);

            // Post-Alloc Block for ELM Copy2
            MIL.MbufClear(ELMCopy2, MIL.M_COLOR_BLACK);

            MIL.MblobAlloc(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobContext);

            // Control Block for Blob Context
            MIL.MblobControl(BlobContext, MIL.M_BLOB_CONTRAST, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_BREADTH, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CENTER_OF_GRAVITY + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CENTER_OF_GRAVITY + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_COMPACTNESS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONTACT_POINTS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONVEX_HULL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_CONVEX_PERIMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_EULER_NUMBER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_PRINCIPAL_AXIS_ANGLE + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_PRINCIPAL_AXIS_ANGLE + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_SECONDARY_AXIS_ANGLE + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_AT_SECONDARY_AXIS_ANGLE + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_CONTACT_POINTS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_GENERAL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_MAX_DIAMETER_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_MIN_DIAMETER_ELONGATION, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PERPENDICULAR_TO_MAX_DIAMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PERPENDICULAR_TO_MIN_DIAMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PRINCIPAL_AXIS_ELONGATION + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERET_PRINCIPAL_AXIS_ELONGATION + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_FERETS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_INTERCEPT, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_LENGTH, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MAX_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MEAN_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_AREA_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_PERIMETER_BOX, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MIN_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_FIRST_ORDER + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_FIRST_ORDER + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_GENERAL + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_GENERAL + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_SECOND_ORDER + MIL.M_BINARY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_MOMENT_SECOND_ORDER + MIL.M_GRAYSCALE, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_NUMBER_OF_HOLES, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_PERIMETER, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_RECTANGULARITY, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_ROUGHNESS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_RUNS, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SIGMA_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SUM_PIXEL, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_SUM_PIXEL_SQUARED, MIL.M_ENABLE);
            MIL.MblobControl(BlobContext, MIL.M_WORLD_BOX, MIL.M_ENABLE);

            MIL.MblobAllocResult(MilSystem, MIL.M_DEFAULT, MIL.M_DEFAULT, ref BlobResult);

            MIL.MbufCopy(ELM_18_70, ELMCopy);
            MIL.MgraAlloc(MilSystem, ref GraphicsContext);
            MIL.MgraLines(GraphicsContext, ELMCopy, NumberOfLinesOrVertices, Polygon, Polygon0, IntPtr.Zero, IntPtr.Zero, MIL.M_POLYGON + MIL.M_FILLED);
            MIL.MimConvert(ELMCopy, MimConvertdestination, MIL.M_RGB_TO_L);
            MIL.MimBinarize(MimConvertdestination, MimBinarizedestination, MIL.M_FIXED + MIL.M_GREATER, 200.0, MIL.M_NULL);
            MIL.MblobCalculate(BlobContext, MimBinarizedestination, MIL.M_NULL, BlobResult);
            MIL.MblobSelect(BlobResult, MIL.M_INCLUDE_ONLY, MIL.M_AREA, MIL.M_GREATER, 1000.0, MIL.M_NULL);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_AXIS_PRINCIPAL_ANGLE + MIL.M_BINARY, ref AxisPrincipalAngle);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_AXIS_SECONDARY_ANGLE + MIL.M_BINARY, ref AxisSecondaryAngle);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_CENTER_OF_GRAVITY_X + MIL.M_BINARY, ref CenterOfGravityX);
            MIL.MblobGetResult(BlobResult, MIL.M_BLOB_INDEX(0), MIL.M_CENTER_OF_GRAVITY_Y + MIL.M_BINARY, ref CenterOfGravityY);
            MIL.MbufCopy(ELM_18_70, ELMCopy2);
            MIL.McalUniform(ELMCopy2, 0.0, 0.0, 1.0, 1.0, 0.0, MIL.M_DEFAULT);
            MIL.McalFixture(ELMCopy2, MIL.M_NULL, MIL.M_MOVE_RELATIVE, MIL.M_POINT_AND_ANGLE, ELMCopy2, CenterOfGravityX, CenterOfGravityY, AxisPrincipalAngle, MIL.M_DEFAULT);
            MIL.MgraAlloc(MilSystem, ref GraphicsContext2);
            MIL.MgraControl(GraphicsContext2, MIL.M_INPUT_UNITS, MIL.M_WORLD);
            MIL.MgraControl(GraphicsContext2, MIL.M_COLOR, MIL.M_COLOR_GREEN);
            MIL.MgraLines(GraphicsContext2, ELMCopy2, NumberOfLinesOrVertices0, InfiniteLines, InfiniteLines0, InfiniteLines1, InfiniteLines2, MIL.M_INFINITE_LINES);
            MIL.MgraAlloc(MilSystem, ref GraphicsContext3);
            MIL.MblobDraw(GraphicsContext3, BlobResult, ELMCopy2, MIL.M_DRAW_BLOBS_CONTOUR + MIL.M_DRAW_CENTER_OF_GRAVITY, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT);
            MIL.MbufSave(@"C:\Users\Admin\Desktop\ManualBlob\result.jpg", ELMCopy2);

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadKey();

            MIL.MgraFree(GraphicsContext3);
            MIL.MgraFree(GraphicsContext2);
            MIL.MgraFree(GraphicsContext);
            MIL.MblobFree(BlobResult);
            MIL.MblobFree(BlobContext);
            MIL.MbufFree(ELMCopy2);
            MIL.MbufFree(MimBinarizedestination);
            MIL.MbufFree(MimConvertdestination);
            MIL.MbufFree(ELMCopy);
            MIL.MbufFree(ELM_18_70);
            MIL.MsysFree(MilSystem);
            MIL.MappFree(MilApplication);
        }
    }
}

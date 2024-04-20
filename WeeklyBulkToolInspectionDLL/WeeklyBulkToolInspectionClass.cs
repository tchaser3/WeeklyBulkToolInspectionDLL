/* Title:           Weekly Bulk Tool Inspection Class
 * Date:            8-14-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class file to access weekly bulk tools inspection */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WeeklyBulkToolInspectionDLL
{
    public class WeeklyBulkToolInspectionClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        WeeklyBulkToolInspectionDataSet aWeeklyBulkToolInspectionDataSet;
        WeeklyBulkToolInspectionDataSetTableAdapters.weeklybulktoolinspectionTableAdapter aWeeklyBulkToolInspectionTableAdapter;

        InsertWeeklyBulkToolInspectEntryTableAdapters.QueriesTableAdapter aInsertWeeklyBulkToolInspectionTableAdapter;

        FindWeeklyBulkToolInspectionByInspectionIDDataSet aFindWeeklyBulktoolInspectionbyInspectionIDDataSet;
        FindWeeklyBulkToolInspectionByInspectionIDDataSetTableAdapters.FindWeeklyBulkToolInspectionByInspectionIDTableAdapter aFindWeeklyBulkToolInspectionByInspectionIDTableAdapter;

        public FindWeeklyBulkToolInspectionByInspectionIDDataSet FindWeeklyBulkToolInspectionByInspectionID(int intInspectionID)
        {
            try
            {
                aFindWeeklyBulktoolInspectionbyInspectionIDDataSet = new FindWeeklyBulkToolInspectionByInspectionIDDataSet();
                aFindWeeklyBulkToolInspectionByInspectionIDTableAdapter = new FindWeeklyBulkToolInspectionByInspectionIDDataSetTableAdapters.FindWeeklyBulkToolInspectionByInspectionIDTableAdapter();
                aFindWeeklyBulkToolInspectionByInspectionIDTableAdapter.Fill(aFindWeeklyBulktoolInspectionbyInspectionIDDataSet.FindWeeklyBulkToolInspectionByInspectionID, intInspectionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Bulk Tool Inspection Class // Find Weekly Bulk Tool Inspection By Inspection ID " + Ex.Message);
            }

            return aFindWeeklyBulktoolInspectionbyInspectionIDDataSet;
        }
        public bool InsertWeeklyBulkVehicleToolInspection(int intInspectionID, int intVehicleID, bool blnToolsPresent, string strInspectionNotes, bool blnConesCorrect, bool blnSignsCorrect, bool blnFirstAidCorrect, bool blnFireExtinguiserCorrect)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWeeklyBulkToolInspectionTableAdapter = new InsertWeeklyBulkToolInspectEntryTableAdapters.QueriesTableAdapter();
                aInsertWeeklyBulkToolInspectionTableAdapter.InsertWeeklyBulkToolInspection(intInspectionID, intVehicleID, DateTime.Now, blnToolsPresent, strInspectionNotes, blnConesCorrect, blnSignsCorrect, blnFirstAidCorrect, blnFireExtinguiserCorrect);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Bulk Tool Inspection // Insert Weekly Bulk Tool Inspection " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WeeklyBulkToolInspectionDataSet GetWeeklyBulktoolInspectionInfo()
        {
            try
            {
                aWeeklyBulkToolInspectionDataSet = new WeeklyBulkToolInspectionDataSet();
                aWeeklyBulkToolInspectionTableAdapter = new WeeklyBulkToolInspectionDataSetTableAdapters.weeklybulktoolinspectionTableAdapter();
                aWeeklyBulkToolInspectionTableAdapter.Fill(aWeeklyBulkToolInspectionDataSet.weeklybulktoolinspection);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Bulk Tool Inspection Class // Get Weekly Bulk Tool Inspection Info " + Ex.Message);
            }

            return aWeeklyBulkToolInspectionDataSet;
        }
        public void UpdateWeeklyBulkToolInspectionDB(WeeklyBulkToolInspectionDataSet aWeeklyBulkToolInspectionDataSet)
        {
            try
            {
                aWeeklyBulkToolInspectionTableAdapter = new WeeklyBulkToolInspectionDataSetTableAdapters.weeklybulktoolinspectionTableAdapter();
                aWeeklyBulkToolInspectionTableAdapter.Update(aWeeklyBulkToolInspectionDataSet.weeklybulktoolinspection);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Weekly Bulk Tool Inspection Class // Get Weekly Bulk Tool Inspection Info " + Ex.Message);
            }
        }
    }
}

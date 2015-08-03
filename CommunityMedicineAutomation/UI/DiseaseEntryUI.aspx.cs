﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomation.BLL;
using CommunityMedicineAutomation.Model;

namespace CommunityMedicineAutomation.UI
{
    public partial class DiseaseEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            diseaseEntryGridView.DataSource = diseaseManager.GetAllDiseases();
            diseaseEntryGridView.DataBind();
        }

        DiseaseManager diseaseManager=new DiseaseManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Disease aDisease=new Disease();

            aDisease.NameOfDisease = nameDiseaseEntryTextBox.Text;
            aDisease.Description = descriptionDiseaseEntryTextBox.Text;
            aDisease.TreatmentProcedure = treatmentProcedureDiseaseEntryTextBox.Text;
            msgLabel.Text = diseaseManager.SaveDisease(aDisease);
            diseaseEntryGridView.DataSource = diseaseManager.GetAllDiseases();
            diseaseEntryGridView.DataBind();

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            diseaseEntryGridView.PageIndex = e.NewPageIndex;
            diseaseEntryGridView.DataBind();
        }

     
    }
}
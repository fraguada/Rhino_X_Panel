﻿using Eto.Drawing;
using Eto.Forms;
using Rhino.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoXPanel
{
    [System.Runtime.InteropServices.Guid("FC80A8F4-65E3-4E01-BB12-DFFC73804B08")]
    public class RhinoXPanelUI : Panel, IPanel
    {
        /// <summary>
        /// Provide easy access to the SampleCsEtoPanel.GUID
        /// </summary>
        public static System.Guid PanelId => typeof(RhinoXPanelUI).GUID;

        private readonly uint m_document_sn;

        /// <summary>
        /// Required public constructor with NO parameters
        /// </summary>
        public RhinoXPanelUI(uint documentSerialNumber)
        {
            m_document_sn = documentSerialNumber;

            var document_sn_label = new Label() { Text = $"Document serial number: {documentSerialNumber}" };

            var layout = new DynamicLayout { DefaultSpacing = new Size(5, 5), Padding = new Padding(10) };
            layout.AddSeparateRow(document_sn_label, null);
            layout.Add(null);
            Content = layout;

        }

        #region IPanel methods

#if WIN
        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is made visible, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel shown for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is hidden, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel hidden for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            // Called when the document or panel container is closed/destroyed
            Rhino.RhinoApp.WriteLine($"Panel closing for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }
#elif MAC

        public void PanelShown(uint documentSerialNumber)
        {
			Rhino.RhinoApp.WriteLine($"Panel shown for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber)
        {
			Rhino.RhinoApp.WriteLine($"Panel hidden for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelClosing(uint documentSerialNumber)
        {
            Rhino.RhinoApp.WriteLine($"Panel closing for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }
#endif

#endregion IPanel methods
    }
}

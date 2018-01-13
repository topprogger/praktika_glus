<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class repForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.posReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.resReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.senReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.posylkiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.posDataSet = New praktika_glus.posDataSet()
        Me.posylkiTableAdapter = New praktika_glus.posDataSetTableAdapters.posylkiTableAdapter()
        CType(Me.posylkiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.posDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'posReport
        '
        ReportDataSource2.Name = "posDs"
        ReportDataSource2.Value = Me.posylkiBindingSource
        Me.posReport.LocalReport.DataSources.Add(ReportDataSource2)
        Me.posReport.LocalReport.ReportEmbeddedResource = "praktika_glus.Report2.rdlc"
        Me.posReport.Location = New System.Drawing.Point(12, 0)
        Me.posReport.Name = "posReport"
        Me.posReport.Size = New System.Drawing.Size(760, 188)
        Me.posReport.TabIndex = 0
        '
        'resReport
        '
        Me.resReport.Location = New System.Drawing.Point(12, 194)
        Me.resReport.Name = "resReport"
        Me.resReport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.resReport.Size = New System.Drawing.Size(760, 188)
        Me.resReport.TabIndex = 1
        '
        'senReport
        '
        Me.senReport.Location = New System.Drawing.Point(12, 388)
        Me.senReport.Name = "senReport"
        Me.senReport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.senReport.Size = New System.Drawing.Size(760, 188)
        Me.senReport.TabIndex = 2
        '
        'posylkiBindingSource
        '
        Me.posylkiBindingSource.DataMember = "posylki"
        Me.posylkiBindingSource.DataSource = Me.posDataSet
        '
        'posDataSet
        '
        Me.posDataSet.DataSetName = "posDataSet"
        Me.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'posylkiTableAdapter
        '
        Me.posylkiTableAdapter.ClearBeforeFill = True
        '
        'repForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 607)
        Me.Controls.Add(Me.senReport)
        Me.Controls.Add(Me.resReport)
        Me.Controls.Add(Me.posReport)
        Me.Name = "repForm"
        Me.Text = "regForm"
        CType(Me.posylkiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.posDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents posReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents resReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents senReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents posylkiBindingSource As BindingSource
    Friend WithEvents posDataSet As posDataSet
    Friend WithEvents posylkiTableAdapter As posDataSetTableAdapters.posylkiTableAdapter
End Class

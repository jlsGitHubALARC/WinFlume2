
'*************************************************************************************************************
' Class ctl_GroupBox - inhertited from Window's GroupBox to add functionality
'*************************************************************************************************************
Imports System
Imports System.Drawing

Public Class ctl_GroupBox

    Protected mBlackPen1 As Drawing.Pen = BlackPen1()

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
        Dim eGraphics As Graphics = e.Graphics

        ' Get size of GroupBox border to draw (so it can be easily seen!)
        Dim height As Integer = e.ClipRectangle.Height
        Dim width As Integer = e.ClipRectangle.Width

        Dim TL As Point = New Point(0, 8)                   ' Top-Left point of GroupBox border
        Dim BR As Point = New Point(width - 1, height - 2)  ' Bottom-Right

        ' Get size of Text to limit border drawing
        Dim siz As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
        Dim txtL As Integer = 5
        Dim txtR As Integer = siz.Width + txtL

        ' Draw the GroupBox border
        eGraphics.DrawLine(mBlackPen1, TL.X, TL.Y, txtL, TL.Y)  ' Top lines bracketing Text
        eGraphics.DrawLine(mBlackPen1, txtR, TL.Y, BR.X, TL.Y)
        eGraphics.DrawLine(mBlackPen1, TL.X, TL.Y, TL.X, BR.Y)  ' Left edge
        eGraphics.DrawLine(mBlackPen1, BR.X, TL.Y, BR.X, BR.Y)  ' Right edge
        eGraphics.DrawLine(mBlackPen1, BR.X, BR.Y, TL.X, BR.Y)  ' Bottom edge

    End Sub

End Class

using AutoCAD;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadConvert.Bussiness
{
    public class DefaultTask : AbstractTask
    {
        System.Timers.Timer aTimer;
        private double bili = 1.0;
        public override void Run()
        {
            //1.获取要替换图号的规则
            HistoryDto dto = Util.GetDrwingsDto(this.TaskName);
            this.KillFlag = false;
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timers_Timer_Elapsed);
            try
            {
                this.AcadDoc = this.AcAppComObj.Documents.Open(this.AbsPath, null, null);
            }
            catch (Exception ex)
            {
                dto.FileTips = "处理失败," + ex.Message;
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                dto.FileStatus = "2";
                Util.UpdateHistory(dto);
                Util.MoveFile(AbsPath, this.SavePath + "失败的图纸文件" + "\\" + this.TaskName);
                //AcAppComObj.ActiveDocument.SaveAs(this.SavePath + "失败的图纸文件" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                //this.AcadDoc.Close();
                return;
            }
            //TODO 相应方法
            try
            {
                this.KillFlag = true;
                AcadBlocks blocks = this.AcadDoc.Blocks;
                double[] limit = this.AcadDoc.Limits;
                double[] pagesize = new double[2];
                pagesize[0] = Math.Abs(limit[2]) - Math.Abs(limit[0]);
                pagesize[1] = Math.Abs(limit[3]) - Math.Abs(limit[1]);
                var type = "";
                var code = Util.SplitCode(this.TaskName);
                if (code.Length > 2)
                {
                    type = "1";
                }
                else
                {
                    type = "0";
                }

                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        bili = Util.CountBili(entity);
                    }
                }

                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        //2.替换审核者、设计者、日期等属性
                        Util.ReplaceProperty(entity, blocks, limit, type, bili);
                        //3.替换装配图中的明细表中的编号
                        //Util.ReplaceDrawingCode(entity, AcAppComObj);
                        //entity.Update();
                    }
                }
                dto.FileTips = "处理完成";
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                dto.FileStatus = "1";
                //4.更新处理状态
                Util.UpdateHistory(dto);
                //5.保存处理后的图纸编号
                Util.InsertCode(Util.oldCode, Util.newCode);

                var fileName = Util.SplitCode(Util.newCode);
                if (AcAppComObj.ActiveDocument.Saved == false)
                {
                    //AcAppComObj.ActiveDocument.SaveAs(this.SavePath + fileName + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                    AcAppComObj.ActiveDocument.SaveAs(this.SavePath + "123456789" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                    this.AcadDoc.Close();
                    GC.Collect();

                }
            }
            catch (Exception ex)
            {
                dto.FileTips = "处理失败," + ex.Message;
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                dto.FileStatus = "2";
                Util.UpdateHistory(dto);
                Util.MoveFile(AbsPath, this.SavePath + "失败的图纸文件" + "\\" + this.TaskName);
                //AcAppComObj.ActiveDocument.SaveAs(this.SavePath + "失败的图纸文件" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                this.AcadDoc.Close();
            }
        }

        private void Timers_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!this.KillFlag)
            {
                aTimer.Stop();
                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("acad");
                foreach (System.Diagnostics.Process pkill in ps)
                {
                    pkill.Kill();
                }
            }
        }
    }
}

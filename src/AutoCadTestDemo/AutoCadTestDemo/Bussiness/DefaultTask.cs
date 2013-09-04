﻿using AutoCAD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class DefaultTask : AbstractTask
    {
        System.Timers.Timer aTimer;
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
                dto.FileStatus = "处理失败," + ex.Message;
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                Util.UpdateHistory(dto);
                Util.MoveFile(AbsPath, this.SavePath + "失败的图纸文件" + "\\" + this.TaskName);
                //AcAppComObj.ActiveDocument.SaveAs(this.SavePath + "失败的图纸文件" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                //this.AcadDoc.Close();
                return;
            }
            //TODO 相应方法
            this.KillFlag = true;
            AcadBlocks blocks = this.AcadDoc.Blocks;
            
            //HistoryDto dto = Util.GetDrwingsDto(AcadDoc.Name);
            try
            {
                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        //2.替换审核者、设计者、日期等属性
                        Util.ReplaceProperty(entity, blocks, this.GetDefaultRules());
                        //3.替换装配图中的明细表中的编号
                        Util.ReplaceDrawingCode(entity, AcAppComObj);
                        entity.Update();
                    }
                }
                dto.FileStatus = "处理完成";
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                //4.更新处理状态
                Util.UpdateHistory(dto);
                //5.保存处理后的图纸编号
                Util.InsertCode(Util.oldCode, Util.newCode);

                var fileName = Util.SplitCode(Util.newCode);
                if (AcAppComObj.ActiveDocument.Saved == false)
                {
                    AcAppComObj.ActiveDocument.SaveAs(this.SavePath + fileName + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                    this.AcadDoc.Close();
                    GC.Collect();

                }
            }
            catch (Exception ex)
            {
                dto.FileStatus = "处理失败," + ex.Message;
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                Util.UpdateHistory(dto);
                Util.MoveFile(AbsPath, this.SavePath + "失败的图纸文件" + "\\" + AcadDoc.Name);
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

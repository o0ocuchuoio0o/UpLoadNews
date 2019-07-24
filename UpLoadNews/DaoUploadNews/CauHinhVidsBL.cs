using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DaoUploadNews
{
    public class CauHinhVidsBL
    {
        private XmlDocument doc;
        private XmlElement root;
        public CauHinhVidsBE docdulieu(string strpath)
        {  //khoi tao bien va load tai lieu xml
            CauHinhVidsBE cauhinh = new CauHinhVidsBE();

            doc = new XmlDocument();

            doc.Load(strpath);
            //duyet den cac nut cua xml
            root = doc.DocumentElement;

            string _cbAutoFitImages = root.SelectSingleNode("_cbAutoFitImages").InnerText;
            string _cbKeepAspectRatio = root.SelectSingleNode("_cbKeepAspectRatio").InnerText;
            string _tbBackgroundImage = root.SelectSingleNode("_tbBackgroundImage").InnerText;
            string _tbMovieWidth = root.SelectSingleNode("_tbMovieWidth").InnerText;
            string _tbMovieHeight = root.SelectSingleNode("_tbMovieHeight").InnerText;
            string _tbAudioTrack = root.SelectSingleNode("_tbAudioTrack").InnerText;
            string _cmbAviAudioCodecs = root.SelectSingleNode("_cmbAviAudioCodecs").InnerText;
            string _cmbAviVideoCodecs = root.SelectSingleNode("_cmbAviVideoCodecs").InnerText;
            string _cmbWmvAudioCodecs = root.SelectSingleNode("_cmbWmvAudioCodecs").InnerText;
            string _cmbWmvAudioFormats = root.SelectSingleNode("_cmbWmvAudioFormats").InnerText;
            string _cmbWmvVideoCodecs = root.SelectSingleNode("_cmbWmvVideoCodecs").InnerText;
            string _tbBitrate = root.SelectSingleNode("_tbBitrate").InnerText;
            string _tbFPS = root.SelectSingleNode("_tbFPS").InnerText;
            string _nudSlideDuration = root.SelectSingleNode("_nudSlideDuration").InnerText;
            string _cmbSlideRotation = root.SelectSingleNode("_cmbSlideRotation").InnerText;
            string _cmbVisualEffect = root.SelectSingleNode("_cmbVisualEffect").InnerText;
            string _cmbVisualEffectTransition = root.SelectSingleNode("_cmbVisualEffectTransition").InnerText;
            string _EffectDuration = root.SelectSingleNode("_EffectDuration").InnerText;
            string _cbTransitionEffectBeforeRandom = root.SelectSingleNode("_cbTransitionEffectBeforeRandom").InnerText;
            string _cmbTransitionEffectBefore = root.SelectSingleNode("_cmbTransitionEffectBefore").InnerText;
            string _nudTransitionEffectBeforeDuration = root.SelectSingleNode("_nudTransitionEffectBeforeDuration").InnerText;
            string _cbTransitionEffectAfterRandom = root.SelectSingleNode("_cbTransitionEffectAfterRandom").InnerText;
            string _cmbTransitionEffectAfter = root.SelectSingleNode("_cmbTransitionEffectAfter").InnerText;
            string _nudTransitionEffectAfterDuration = root.SelectSingleNode("_nudTransitionEffectAfterDuration").InnerText;
            //gan cac nut cua xml vao bien khoi tao trong bo luu tru

            cauhinh.CbAutoFitImages = _cbAutoFitImages;
            cauhinh.CbKeepAspectRatio = _cbKeepAspectRatio;
            cauhinh.TbBackgroundImage = _tbBackgroundImage;
            cauhinh.TbMovieWidth = _tbMovieWidth;
            cauhinh.TbMovieHeight = _tbMovieHeight;
            cauhinh.TbAudioTrack = _tbAudioTrack;
            cauhinh.CmbAviAudioCodecs = _cmbAviAudioCodecs;
            cauhinh.CmbAviVideoCodecs = _cmbAviVideoCodecs;
            cauhinh.CmbWmvAudioCodecs = _cmbWmvAudioCodecs;
            cauhinh.CmbWmvAudioFormats = _cmbWmvAudioFormats;
            cauhinh.CmbWmvVideoCodecs = _cmbWmvVideoCodecs;
            cauhinh.TbBitrate = _tbBitrate;
            cauhinh.TbFPS = _tbFPS;
            cauhinh.NudSlideDuration = _nudSlideDuration;
            cauhinh.CmbSlideRotation = _cmbSlideRotation;
            cauhinh.CmbVisualEffect = _cmbVisualEffect;
            cauhinh.CmbVisualEffectTransition = _cmbVisualEffectTransition;
            cauhinh.EffectDuration = _EffectDuration;
            cauhinh.CbTransitionEffectBeforeRandom = _cbTransitionEffectBeforeRandom;
            cauhinh.CmbTransitionEffectBefore = _cmbTransitionEffectBefore;
            cauhinh.NudTransitionEffectBeforeDuration = _nudTransitionEffectBeforeDuration;
            cauhinh.CbTransitionEffectAfterRandom = _cbTransitionEffectAfterRandom;
            cauhinh.CmbTransitionEffectAfter = _cmbTransitionEffectAfter;
            cauhinh.NudTransitionEffectAfterDuration = _nudTransitionEffectAfterDuration;            
            return cauhinh;
        }
        //methor ghi du lieu len xml 
        public void ghidulieu(CauHinhVidsBE cauhinh, string strpath)
        {
            doc = new XmlDocument();

            root = doc.CreateElement("CAUHINH");
            XmlElement _cbAutoFitImages = root.OwnerDocument.CreateElement("_cbAutoFitImages");
            _cbAutoFitImages.InnerText = cauhinh.CbAutoFitImages;
            XmlElement _cbKeepAspectRatio = root.OwnerDocument.CreateElement("_cbKeepAspectRatio");
            _cbKeepAspectRatio.InnerText = cauhinh.CbKeepAspectRatio;
            XmlElement _tbBackgroundImage = root.OwnerDocument.CreateElement("_tbBackgroundImage");
            _tbBackgroundImage.InnerText = cauhinh.TbBackgroundImage;
            XmlElement _tbMovieWidth = root.OwnerDocument.CreateElement("_tbMovieWidth");
            _tbMovieWidth.InnerText = cauhinh.TbMovieWidth;
            XmlElement _tbMovieHeight = root.OwnerDocument.CreateElement("_tbMovieHeight");
            _tbMovieHeight.InnerText = cauhinh.TbMovieHeight;
            XmlElement _tbAudioTrack = root.OwnerDocument.CreateElement("_tbAudioTrack");
            _tbAudioTrack.InnerText = cauhinh.TbAudioTrack;
            XmlElement _cmbAviAudioCodecs = root.OwnerDocument.CreateElement("_cmbAviAudioCodecs");
            _cmbAviAudioCodecs.InnerText = cauhinh.CmbAviAudioCodecs;
            XmlElement _cmbAviVideoCodecs = root.OwnerDocument.CreateElement("_cmbAviVideoCodecs");
            _cmbAviVideoCodecs.InnerText = cauhinh.CmbAviVideoCodecs;
            XmlElement _cmbWmvAudioCodecs = root.OwnerDocument.CreateElement("_cmbWmvAudioCodecs");
            _cmbWmvAudioCodecs.InnerText = cauhinh.CmbWmvAudioCodecs;
            XmlElement _cmbWmvAudioFormats = root.OwnerDocument.CreateElement("_cmbWmvAudioFormats");
            _cmbWmvAudioFormats.InnerText = cauhinh.CmbWmvAudioFormats;
            XmlElement _cmbWmvVideoCodecs = root.OwnerDocument.CreateElement("_cmbWmvVideoCodecs");
            _cmbWmvVideoCodecs.InnerText = cauhinh.CmbWmvVideoCodecs;
            XmlElement _tbBitrate = root.OwnerDocument.CreateElement("_tbBitrate");
            _tbBitrate.InnerText = cauhinh.TbBitrate;
            XmlElement _tbFPS = root.OwnerDocument.CreateElement("_tbFPS");
            _tbFPS.InnerText = cauhinh.TbFPS;
            XmlElement _nudSlideDuration = root.OwnerDocument.CreateElement("_nudSlideDuration");
            _nudSlideDuration.InnerText = cauhinh.NudSlideDuration;
            XmlElement _cmbSlideRotation = root.OwnerDocument.CreateElement("_cmbSlideRotation");
            _cmbSlideRotation.InnerText = cauhinh.CmbSlideRotation;
            XmlElement _cmbVisualEffect = root.OwnerDocument.CreateElement("_cmbVisualEffect");
            _cmbVisualEffect.InnerText = cauhinh.CmbVisualEffect;
            XmlElement _cmbVisualEffectTransition = root.OwnerDocument.CreateElement("_cmbVisualEffectTransition");
            _cmbVisualEffectTransition.InnerText = cauhinh.CmbVisualEffectTransition;
            XmlElement _EffectDuration = root.OwnerDocument.CreateElement("_EffectDuration");
            _EffectDuration.InnerText = cauhinh.EffectDuration;
            XmlElement _cbTransitionEffectBeforeRandom = root.OwnerDocument.CreateElement("_cbTransitionEffectBeforeRandom");
            _cbTransitionEffectBeforeRandom.InnerText = cauhinh.CbTransitionEffectBeforeRandom;
            XmlElement _cmbTransitionEffectBefore = root.OwnerDocument.CreateElement("_cmbTransitionEffectBefore");
            _cmbTransitionEffectBefore.InnerText = cauhinh.CmbTransitionEffectBefore;
            XmlElement _nudTransitionEffectBeforeDuration = root.OwnerDocument.CreateElement("_nudTransitionEffectBeforeDuration");
            _nudTransitionEffectBeforeDuration.InnerText = cauhinh.NudTransitionEffectBeforeDuration;
            XmlElement _cbTransitionEffectAfterRandom = root.OwnerDocument.CreateElement("_cbTransitionEffectAfterRandom");
            _cbTransitionEffectAfterRandom.InnerText = cauhinh.CbTransitionEffectAfterRandom;
            XmlElement _cmbTransitionEffectAfter = root.OwnerDocument.CreateElement("_cmbTransitionEffectAfter");
            _cmbTransitionEffectAfter.InnerText = cauhinh.CmbTransitionEffectAfter;
            XmlElement _nudTransitionEffectAfterDuration = root.OwnerDocument.CreateElement("_nudTransitionEffectAfterDuration");
            _nudTransitionEffectAfterDuration.InnerText = cauhinh.NudTransitionEffectAfterDuration;            
            
          
            doc.AppendChild(root);
            root.AppendChild(_cbAutoFitImages);
            root.AppendChild(_cbKeepAspectRatio);
            root.AppendChild(_tbBackgroundImage);
            root.AppendChild(_tbMovieWidth);
            root.AppendChild(_tbMovieHeight);
            root.AppendChild(_tbAudioTrack);
            root.AppendChild(_cmbAviAudioCodecs);
            root.AppendChild(_cmbAviVideoCodecs);
            root.AppendChild(_cmbWmvAudioCodecs);
            root.AppendChild(_cmbWmvAudioFormats);
            root.AppendChild(_cmbWmvVideoCodecs);
            root.AppendChild(_tbBitrate);
            root.AppendChild(_tbFPS);
            root.AppendChild(_nudSlideDuration);
            root.AppendChild(_cmbSlideRotation);
            root.AppendChild(_cmbVisualEffect);
            root.AppendChild(_cmbVisualEffectTransition);
            root.AppendChild(_EffectDuration);
            root.AppendChild(_cbTransitionEffectBeforeRandom);
            root.AppendChild(_cmbTransitionEffectBefore);
            root.AppendChild(_nudTransitionEffectBeforeDuration);
            root.AppendChild(_cbTransitionEffectAfterRandom);
            root.AppendChild(_cmbTransitionEffectAfter);
            root.AppendChild(_nudTransitionEffectAfterDuration);
            doc.Save(strpath);
        }
    }
}

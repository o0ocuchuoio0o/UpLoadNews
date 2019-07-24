using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BytescoutImageToVideo;
using System.Threading;
using System.IO;
using System.Drawing;
using DaoUploadNews;
namespace CreateVideoEffect
{
    class Program
    {
        #region // cac bien cau hinh
     
        private static bool _cbAutoFitImages = true;
        private static bool _cbKeepAspectRatio = true;
        private static string _tbBackgroundImage = "";
        private static int _tbMovieWidth = 1280;
        private static int _tbMovieHeight = 720;
        private static string _tbAudioTrack = "";
        private static int _cmbAviAudioCodecs= 4;
        private static int _cmbAviVideoCodecs=11;
        private static int _cmbWmvAudioCodecs=2;
        private static int _cmbWmvAudioFormats=6;
        private static int _cmbWmvVideoCodecs=5;
        private static int _tbBitrate= 1000;
        private static float _tbFPS= 22;
        private static int _nudSlideDuration=5000;
        private static int _cmbSlideRotation=0;
        private static int _cmbVisualEffect=0;
        private static int _cmbVisualEffectTransition=0;
        private static int _EffectDuration= 2500;
        private static bool _cbTransitionEffectBeforeRandom = true;
        private static int _cmbTransitionEffectBefore=0;
        private static int _nudTransitionEffectBeforeDuration= 2500;
        private static bool _cbTransitionEffectAfterRandom = true;
        private static int _cmbTransitionEffectAfter=0;
        private static int _nudTransitionEffectAfterDuration= 2500;
        
        #endregion
        private static  void laythongtinhethong()
        {   
            try
            {
                CauHinhVidsBE hethong = new CauHinhVidsBE();
                CauHinhVidsBL tkxuly = new CauHinhVidsBL();
                //dog nay de load xml trong debug ne
                hethong = tkxuly.docdulieu(Environment.CurrentDirectory + "\\Effect\\CauHinhVids.xml");
                _cbAutoFitImages = bool.Parse(hethong.CbAutoFitImages);
                _cbKeepAspectRatio = bool.Parse(hethong.CbKeepAspectRatio);
                _tbBackgroundImage = hethong.TbBackgroundImage;
                _tbMovieWidth = int.Parse(hethong.TbMovieWidth);
                _tbMovieHeight = int.Parse(hethong.TbMovieHeight);
                _tbAudioTrack = hethong.TbAudioTrack;
                _cmbAviAudioCodecs = int.Parse(hethong.CmbAviAudioCodecs);
                _cmbAviVideoCodecs = int.Parse(hethong.CmbAviVideoCodecs);
                _cmbWmvAudioCodecs = int.Parse(hethong.CmbWmvAudioCodecs);
                _cmbWmvAudioFormats = int.Parse(hethong.CmbWmvAudioFormats);
                _cmbWmvVideoCodecs = int.Parse(hethong.CmbWmvVideoCodecs);
                _tbBitrate = int.Parse(hethong.TbBitrate);
                _tbFPS = float.Parse(hethong.TbFPS);
                _nudSlideDuration = int.Parse(hethong.NudSlideDuration);            
                _cmbSlideRotation = int.Parse(hethong.CmbSlideRotation);
                _cmbVisualEffect = int.Parse(hethong.CmbVisualEffect);
                _cmbVisualEffectTransition = int.Parse(hethong.CmbVisualEffectTransition);
                _EffectDuration = int.Parse(hethong.EffectDuration);
                _cbTransitionEffectBeforeRandom = bool.Parse(hethong.CbTransitionEffectBeforeRandom);
                _cmbTransitionEffectBefore = int.Parse(hethong.CmbTransitionEffectBefore);
                _nudTransitionEffectBeforeDuration = int.Parse(hethong.NudTransitionEffectBeforeDuration);
                _cbTransitionEffectAfterRandom = bool.Parse(hethong.CbTransitionEffectAfterRandom);
                _cmbTransitionEffectAfter = int.Parse(hethong.CmbTransitionEffectAfter);
                _nudTransitionEffectAfterDuration = int.Parse(hethong.NudTransitionEffectAfterDuration);
            }
            catch {
              
            }
          
            }

        #region // ham random effect
        private static Random _randomGenerator = new Random();
        private static TransitionEffectType GetRandomEffect()
        {
            return (TransitionEffectType)_randomGenerator.Next(0, 140);
        }
        #endregion
        public static string[] Getstringrun()
        {
            string[] filerun;
            try
            {

                string scriptDirectory = Environment.CurrentDirectory +@"\\Effect\\Listimage.txt";
                filerun = File.ReadAllLines(scriptDirectory);// kq.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                return filerun;

            }
            catch { return null; }

        }

        static void Main(string[] args)
        {
            try
            {
                Thread.Sleep(5000);
                laythongtinhethong();
                #region // gan bien
                string[] temp = Getstringrun();
                string[] mang = temp[0].ToString().Trim().Split(new string[] { "," }, StringSplitOptions.None);
                _tbBackgroundImage = mang[0].ToString();
                _tbAudioTrack = mang[1].ToString();  
                string _ImageFile = mang[2].ToString();
                int timevideo = int.Parse(mang[3].ToString());               
                if (timevideo> _nudSlideDuration*2)
                {
                    _nudSlideDuration = (timevideo + 3000)/2;
                    _EffectDuration = _nudSlideDuration/2;
                    _nudTransitionEffectBeforeDuration = _EffectDuration;
                    _nudTransitionEffectAfterDuration = _EffectDuration;
                }
                string _outputFile = mang[4].ToString();              

                #endregion

                #region // tao video
                    ImageToVideo _imageToVideo = new ImageToVideo();
                _imageToVideo.RegistrationName = "support@bytescout.com";
                _imageToVideo.RegistrationKey = "EC19-39EC-4361-66B4-372";
                if (!_imageToVideo.IsRunning)
                {
                    _imageToVideo.AutoFitImages = _cbAutoFitImages;
                    _imageToVideo.KeepAspectRatio = _cbKeepAspectRatio;
                    if (_tbBackgroundImage != "") {
                        _imageToVideo.SetBackgroundPictureFileName(_tbBackgroundImage);
                    }
                    _imageToVideo.OutputWidth = _tbMovieWidth;
                    _imageToVideo.OutputHeight = _tbMovieHeight;
                    //if (_tbAudioTrack != "") {
                    //    _imageToVideo.ExternalAudioTrackFromFileName = _tbAudioTrack;
                    //}
                    //_imageToVideo.CurrentAudioCodec = int.Parse(mang[5].ToString());                  
                    //_imageToVideo.CurrentVideoCodec = int.Parse(mang[6].ToString());
                    //_imageToVideo.CurrentWMVAudioCodec = int.Parse(mang[7].ToString());
                    //_imageToVideo.CurrentWMVAudioFormat = int.Parse(mang[8].ToString());
                    _imageToVideo.CurrentWMVVideoCodec = _cmbWmvVideoCodecs;
                    _imageToVideo.WMVVideoBitrate = _tbBitrate* 1024;
                    _imageToVideo.FPS = _tbFPS;
                    _imageToVideo.OutputVideoFileName = _outputFile;
                    _imageToVideo.Slides.Clear();
                    for (int i = 1; i <= 2; i++)
                    {
                        Slide slide = _imageToVideo.AddImageFromFileName(_ImageFile);
                        slide.Duration = _nudSlideDuration;
                        //slide.RotationAngle = (RotationAngle)_cmbSlideRotation;
                        //slide.VisualEffect = (VisualEffectType)_cmbVisualEffect;
                        //slide.Effect = (SlideEffectType)_cmbVisualEffectTransition;
                        //slide.EffectDuration = _EffectDuration;
                        Random rnd = new Random();
                        int randomeffect = rnd.Next(3, 140);
                        slide.InEffect = (TransitionEffectType)randomeffect;// _cbTransitionEffectBeforeRandom ? GetRandomEffect() : (TransitionEffectType)(_cmbTransitionEffectBefore - 1); ;
                        slide.InEffectDuration = _nudTransitionEffectBeforeDuration;
                        Random rnd2 = new Random();
                        int randomeffect2 = rnd2.Next(3, 140);
                        slide.OutEffect = (TransitionEffectType)randomeffect2;//_cbTransitionEffectAfterRandom ? GetRandomEffect() : (TransitionEffectType)(_cmbTransitionEffectAfter - 1); ;
                        slide.OutEffectDuration = _nudTransitionEffectAfterDuration;
                    }
                    _imageToVideo.Run();
               
                    try
                    {
                        int i = 0;
                        char[] spin = new char[] { '|', '/', '-', '\\' };

                        while (!Console.KeyAvailable && _imageToVideo.IsRunning)
                        {
                            float progress = _imageToVideo.ConversionProgress;
                            Console.WriteLine(String.Format("...o0ocuchuoio0o----:progress video {0}% {1}", progress, spin[i++]));
                            Console.CursorTop--;
                            i %= 4;
                            Thread.Sleep(500);
                        }

                        if (_imageToVideo.IsRunning)
                        {                          
                            _imageToVideo.Stop();
                            Console.WriteLine("Conversion aborted by user.");
                        }
                        else
                        {
                            Console.WriteLine("Conversion competed successfully.");
                        }
                    }
                    catch { }
                }
                else
                {
                    _imageToVideo.Stop();
                    // wait a bit the converter finished and released resources
                    while (_imageToVideo.IsRunning)
                        Thread.Sleep(500);

                }

                #endregion
            }
            catch {
                //Console.WriteLine(ex.ToString());
                //Console.ReadLine();
            }
        }
        }

    }
    

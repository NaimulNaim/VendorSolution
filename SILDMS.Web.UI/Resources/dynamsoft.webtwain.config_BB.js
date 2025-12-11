//
// Dynamsoft JavaScript Library for Basic Initiation of Dynamic Web TWAIN
// More info on DWT: http://www.dynamsoft.com/Products/WebTWAIN_Overview.aspx
//
// Copyright 2016, Dynamsoft Corporation 
// Author: Dynamsoft Team
// Version: 12.0
//
/// <reference path="dynamsoft.webtwain.initiate.js" />
var Dynamsoft = Dynamsoft || { WebTwainEnv: {} };


Dynamsoft.WebTwainEnv.AutoLoad = true;
///
Dynamsoft.WebTwainEnv.Containers = [{ ContainerId: 'dwtHorizontalThumbnil', Width: 100 + '%', Height: 200 },
{ ContainerId: 'dwtVerticalThumbnil', Width: 150, Height: 500 },
{ ContainerId: 'dwtLargeViewer', Width: 755, Height: 500 },
{ ContainerId: 'dwtQuickViewer', Width: 80 + '%', Height: 500 }];

///
Dynamsoft.WebTwainEnv.ProductKey = '5E039896F6F3ABB74D39CF95015C2B115D76A09AA3FAE6315360A76399E31DCEDCB099CD25F056D3EB31ACEE88D5C58E036717A6112BC8B9DC16AA6D7370B278ECA0CDDD3542B1D84246F8E454EFB4D7F95B702D0AB71833B2A343C46D2195834DCD125EAA1AE77CED735CE2A6AB612072';
///
Dynamsoft.WebTwainEnv.Trial = false;
///
Dynamsoft.WebTwainEnv.ActiveXInstallWithCAB = false;
///
Dynamsoft.WebTwainEnv.Debug = false; // only for debugger output
///
Dynamsoft.WebTwainEnv.ResourcesPath = '../Resources';
///
// Dynamsoft.WebTwainEnv.ResourcesPath = 'Resources';

/// All callbacks are defined in the dynamsoft.webtwain.install.js file, you can customize them.

// Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', function(){
// 		// webtwain has been inited
// });


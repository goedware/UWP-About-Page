# Universal Windows Platform About Page ![version](http://img.shields.io/badge/original-v1.0.2-brightgreen.svg?style=flat) [![NuGet](https://img.shields.io/nuget/v/GoedWare.Controls.About.svg?label=NuGet)](https://www.nuget.org/packages/GoedWare.Controls.About/)
Create an awesome About Page for your Universal Windows Platform (UWP) app in just a few minutes.

Inspired by the android about page created by [medyo](https://github.com/medyo/android-about-page)

This library allows to generate beautiful About Pages for your UWP app with less effort, it's fully customizable and supports custom actions.

**Code Behind**
```csharp
 var aboutControl = new AboutControl()
  .SetImage("ms-appx:///Assets/goedware_logo.jpg", 100)
  .SetDescription("Write here something about your app and/or company")
  .AddVersion()
  .AddEmail("test@mail.com", "My app support")
  .AddWebsite("http://www.goedware.com")
  .AddWindowsStore("familyName")
  .AddTwitter("GoedWare")
  .AddFacebook("GoedWare")
  .AddGitHub("GoedWare")
  .AddInstagram("GoedWare")
  .AddYouTube("UCvJiYiBUbw4tmpRSZT2r1Hw")
  .AddPlayStore("com.whatsapp");
```

**XAML**
```xaml
<about:AboutControl
   ImageSource="Assets/goedware_logo.jpg" 
   ImageHorizontalAlignment="Center"
   ImageVerticalAlignment="Center"
   ImageHeight="100"
   ImageWidth="100" 
   ImageStretch="Uniform"
   Description="This is a sample text description"
   DescriptionAlignment="Center">
   <about:AboutControl.Items>
    <items:VersionItem/>
    <items:EmailItem Subject="Windows Store app"
     AddDeviceAndDebugInformation="True"
     Value="info@windows.com"/>
    <items:WebsiteItem Value="http://www.goedware.com"/>
    <items:WindowsStoreItem/>
    <items:TwitterItem Value="GoedWare"/>
    <items:InstagramItem Value="GoedWare"/>
    <items:YouTubeItem Value="UCvJiYiBUbw4tmpRSZT2r1Hw"/>
    <items:FacebookItem Value="GoedWare"/>
    <items:GitHubItem Value="GoedWare"/>
    <items:PlayStoreItem Value="com.whatsapp"/>
   </about:AboutControl.Items>
</about:AboutControl>
```

## Setup

Grab the latest version from NuGet

> PM Install-Package GoedWare.Controls.About

## Usage
### 1. Add Description

```csharp
SetDescription(string)
```

```xaml
<about:AboutControl
   Description="This is a sample text description"
   DescriptionAlignment="Center">
</about:AboutControl>
```

### 2. Add Image
```csharp
SetImage(string)
SetImage(Stream)
```

```xaml
<about:AboutControl
   ImageSource="Assets/goedware_logo.jpg" 
   ImageHorizontalAlignment="Center"
   ImageVerticalAlignment="Center"
   ImageHeight="100"
   ImageWidth="100" 
   ImageStretch="Uniform"
</about:AboutControl>
```

### 3. Add predefined Social network
The library has already some predefined social networks like :  

* Facebook
* Twitter
* Instagram
* GitHub
* Windows Store
* Youtube
* PlayStore

```csharp
AddFacebook(string account)
AddTwitter(string account)
AddYoutube(string channel)
AddPlayStore(string packageName)
AddInstagram(string account)
AddGitHub(string account)
AddWindowsStore(string familyName)
```

```xaml
<about:AboutControl>
   <about:AboutControl.Items>
    <items:WindowsStoreItem/>
    <items:TwitterItem Value="GoedWare"/>
    <items:InstagramItem Value="GoedWare"/>
    <items:YouTubeItem Value="UCvJiYiBUbw4tmpRSZT2r1Hw"/>
    <items:FacebookItem Value="GoedWare"/>
    <items:GitHubItem Value="GoedWare"/>
    <items:PlayStoreItem Value="com.whatsapp"/>
   </about:AboutControl.Items>
</about:AboutControl>
```

### 4. Add App Package Version
Format: Version Major.Minor.Build 

Example: Version 1.2.6

```csharp
AddVersion()
```

```xaml
<about:AboutControl>
   <about:AboutControl.Items>
    <items:VersionItem/>
   </about:AboutControl.Items>
</about:AboutControl>
```

### 5. Add Website
Browse to specified url

```csharp
AddWebsite(string url)
```

```xaml
<about:AboutControl>
   <about:AboutControl.Items>
    <items:WebsiteItem Value="http://www.goedware.com"/>
   </about:AboutControl.Items>
</about:AboutControl>
```

### 6. Add E-mail
Open mail app to send mail to specified address and optional include device and debug information to message body

```csharp
AddEmail(string address, string subject, bool addDeviceAndDebugInformation)
```

```xaml
<about:AboutControl>
   <about:AboutControl.Items>
    <items:EmailItem Subject="Windows Store app"
     AddDeviceAndDebugInformation="True"
     Value="info@windows.com"/>
   </about:AboutControl.Items>
</about:AboutControl>
```

### 7. Add Custom Item

```csharp
var customItem = new AboutItem()
{
  Title = "Custom about item",
  Foreground = new SolidColorBrush(Colors.BlueViolet),
  Value = "This is a custom about item",
  Icon = new SymbolIcon(Symbol.World),
  Action = async aboutItem =>
  {
    var dialog = new MessageDialog(aboutItem.Value);
    await dialog.ShowAsync();
  }
};

aboutControl.AddItem(customItem);
```

```xaml
<about:AboutControl>
   <about:AboutControl.Items>
    <items:AboutItem Title="Custom about item"
      Value="This is a custom about item">
     <items:AboutItem.Icon>
      <SymbolIcon Symbol="World"/>
     </items:AboutItem.Icon>
    </items:AboutItem>
   </about:AboutControl.Items>
</about:AboutControl>
```

### 8. Available attributes for AboutItem Class

| Function        | Description  |
| ------------- |:-------------:| -----:|
| string Title | Set title of the item|
| Brush Foreground | Set foreground color of the icon|
| IconElement Icon | Set icon of the item|
| string Data | Set data for path icon of the item|
| string Value | Set Item value like Facebook ID|
| Action Action | Set the action of the item that should be invoked on selection|

Choose Data if you have a vector path and use Icon if you want to use a SymbolIcon, PathIcon, BitmapIcon or FontIcon.

### 9. Customization

Customize the about items to your own style by overriding the default templates & styles:

* **AboutItemTemplate:** Override to change the default design templatee of the about items
* **AboutItemContainerStyle:** Override to change the default container style of the about items

## Translations
The library does supports the following languages :

* English (default)
* Dutch (by [goedware](https://github.com/goedware))
* German (by [goedware](https://github.com/goedware))
* French (by [goedware](https://github.com/goedware))
* Italian (by [goedware](https://github.com/goedware))
* Spanish (by [goedware](https://github.com/goedware))

Please make a Pull request to add a new language.

## Sample Project
[sample](https://github.com/goedware/UWP-About-Page/tree/master/GoedWare.Controls.About/GoedWare.Samples.About)

## License

```
The MIT License (MIT)

Copyright (c) 2016 C. Goedegebuure

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

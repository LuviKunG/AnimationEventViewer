# Animation Event Viewer
Animation Event Viewer is an Unity Editor tools for view Animation asset properties includes AnimationEvent and types. Created by Thanut Panichyotai (@[LuviKunG]((https://github.com/LuviKunG)))

## How to use?

To use Animation Event Viewer, simply right click on Animation assets and select **LuviKunG/Animation Event Viewer**

![How to open](images/example01.png)

Animation Event Viewer editor window will show your selected Animation asset and display all animation events (include types and values).

![Animation Event Viewer Editor window](images/example02.png)

## How to install?

### UPM Install via manifest.json

Locate to your Unity Project. In *Packages* folder, you will see a file named **manifest.json**. Open it with your text editor (such as Notepad++ or Visual Studio Code or Legacy Notepad)

Then merge this json format below.

(Do not just copy & paste the whole json! If you are not capable to merge json, please using online JSON merge tools like [this](https://tools.knowledgewalls.com/onlinejsonmerger))

```json
{
  "dependencies": {
    "com.luvikung.animationeventviewer": "https://github.com/LuviKunG/AnimationEventViewer#1.0.0"
  }
}
```

If you want to install the older version, please take a look at release tag in this git, then change the path after **#** to the version tag that you want.

### Unity 2019.3 Git URL

In Unity 2019.3 or greater, Package Manager is include the new feature that able to install the package via Git.

![Install with Git URL](images/giturl.png)

Just simply using this git URL and following with version like this example.

**https://github.com/LuviKunG/GraphicShaders.git#1.0.0**

Make sure that you're select the latest version.
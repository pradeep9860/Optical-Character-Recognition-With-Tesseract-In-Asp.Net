# Optical-Character-Recognition-With-Tesseract-In-Asp.Net
 
## Brief history

Tesseract was originally developed at Hewlett-Packard Laboratories Bristol and
at Hewlett-Packard Co, Greeley Colorado between 1985 and 1994, with some
more changes made in 1996 to port to Windows, and some C++izing in 1998.
In 2005 Tesseract was open sourced by HP. Since 2006 it is developed by Google.

The latest (LSTM based) stable version is **[4.0.0](https://github.com/tesseract-ocr/tesseract/releases/tag/4.0.0)**, released on October 29, 2018. Latest source code for 4.0 is available from [master branch on GitHub](https://github.com/tesseract-ocr/tesseract/tree/master). Open issues can be found in [issue tracker](https://github.com/tesseract-ocr/tesseract/issues), and [Planning wiki](https://github.com/tesseract-ocr/tesseract/wiki/Planning#400).

The latest 3.5 version is **[3.05.02](https://github.com/tesseract-ocr/tesseract/releases/tag/3.05.02)**, released on June 19, 2018. Latest source code for 3.05 is available from [3.05 branch on GitHub](https://github.com/tesseract-ocr/tesseract/tree/3.05). There is no development for this version, but it can be used for special cases (e.g. see [Regression of features from 3.0x](https://github.com/tesseract-ocr/tesseract/wiki/Planning#regression-of-features-from-30x)).

See **[Release Notes](https://github.com/tesseract-ocr/tesseract/wiki/ReleaseNotes)** and **[Change Log](https://github.com/tesseract-ocr/tesseract/blob/master/ChangeLog)** for more details of the releases.

## Installing Tesseract

You can either [Install Tesseract via pre-built binary package](https://github.com/tesseract-ocr/tesseract/wiki) or [build it from source](https://github.com/tesseract-ocr/tesseract/wiki/Compiling).

Supported Compilers are:

* GCC 4.8 and above
* Clang 3.4 and above
* MSVC 2015, 2017

Other compilers might work, but are not officially supported.

## Running Tesseract

Basic **[command line usage](https://github.com/tesseract-ocr/tesseract/wiki/Command-Line-Usage)**:

    tesseract imagename outputbase [-l lang] [--oem ocrenginemode] [--psm pagesegmode] [configfiles...]

For more information about the various command line options use `tesseract --help` or `man tesseract`.

Examples can be found in the [wiki](https://github.com/tesseract-ocr/tesseract/wiki/Command-Line-Usage#simplest-invocation-to-ocr-an-image).

## For developers

Developers can use `libtesseract` [C](https://github.com/tesseract-ocr/tesseract/blob/master/src/api/capi.h) or [C++](https://github.com/tesseract-ocr/tesseract/blob/master/src/api/baseapi.h) API to build their own application. If you need bindings to `libtesseract` for other programming languages, please see the [wrapper](https://github.com/tesseract-ocr/tesseract/wiki/AddOns#tesseract-wrappers) section on AddOns wiki page.

Documentation of Tesseract generated from source code by doxygen can be found on [tesseract-ocr.github.io](http://tesseract-ocr.github.io/).

## Support

Before you submit an issue, please review **[the guidelines for this repository](https://github.com/tesseract-ocr/tesseract/blob/master/CONTRIBUTING.md)**.

For support, first read the [Wiki](https://github.com/tesseract-ocr/tesseract/wiki), particularly the [FAQ](https://github.com/tesseract-ocr/tesseract/wiki/FAQ) to see if your problem is addressed there. If not, search the [Tesseract user forum](https://groups.google.com/d/forum/tesseract-ocr), the [Tesseract developer forum](https://groups.google.com/d/forum/tesseract-dev) and [past issues](https://github.com/tesseract-ocr/tesseract/issues), and if you still can't find what you need, ask for support in the mailing-lists.

Mailing-lists:
* [tesseract-ocr](https://groups.google.com/d/forum/tesseract-ocr) - For tesseract users.
* [tesseract-dev](https://groups.google.com/d/forum/tesseract-dev) - For tesseract developers.

Please report an issue only for a **bug**, not for asking questions.

## License

    The code in this repository is licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.

**NOTE**: This software depends on other packages that may be licensed under different open source licenses.

Tesseract uses [Leptonica library](http://leptonica.com/) which essentially
uses a [BSD 2-clause license](http://leptonica.com/about-the-license.html).

## Latest Version of README

For the latest online version of the README.md see:

https://github.com/tesseract-ocr/tesseract/blob/master/README.md

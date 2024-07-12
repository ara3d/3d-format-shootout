# 3D Format Shoot-out

A set of sample-data, benchmarks, tests, and profiling tools for comparing static 3D scene data formats.

## Getting the Data

This repository uses [Git submodules](https://git-scm.com/book/en/v2/Git-Tools-Submodules) and 
[Git LFS (Large File System)](https://git-lfs.com/). 

To retrieve data with submodules you can clone the repository as follows:

```
git clone --recurse-submodules https://github.com/ara3d/3d-format-shootout
```

Or you can initialize the submodules and retrieve their data after cloning:

```
git submodule update --init --recursive
```

## Structure of Data 

* [Submodules](https://github.com/ara3d/3d-format-shootout/data/submodules) - Some useful open-source 3D repositories of data exist, and have been added as submodules. 
* [Copies](https://github.com/ara3d/3d-format-shootout/tree/main/data/copies) - Other open-source projects (like Three.JS) have useful test files and data sets, but to avoid bringining in everything, we just manually copied 
their test data.
* [Files](https://github.com/ara3d/3d-format-shootout/tree/main/data/files) - Some specific small files are added one-by-one here.
* [Big](https://github.com/ara3d/3d-format-shootout/tree/main/data/big) - Some larger files (e.g., >50MB) are tracked by Git LFS, and are placed here. 
* [Local-Untracked](https://github.com/ara3d/3d-format-shootout/tree/main/data/local-untracked) - Some data requires unzipping/unarchiving before being used and by default scripts will place them in this folder, so that they aren't accidentally pushed online.

# About

This project aims to provide a set of tools for measuring and comparing the capabilities of numerous data/file formats
to process large amounts of static instanced 3D geometry. 

The goal of this project is to understand objectively the tradeoffs involved in the different formats for use in representing 
large AEC data sets, and how they scale for different types of tasks and input. 

We will not be evaluating formats for their ability to convey animations or materials. 

# Motivation

Sufficiently large representations of geometry used in CAD and AEC applications, either take extremely large amounts of time to process 
or will crash the software. This investigation will examine the capabilities of a number of implementations of different format readers and 
writers. 

Rather than relying on anecdotal experience and marketing when choosing a 3D representation, this project aims to provide users and implementors 
with a concrete set of benchmarks to use and compare against when implementing formats.   

# Methodology 

Benchmarking and profiling data formats accurately is impossible because we can only really measure the performance of a particular 
implementation. While the implementation quality is influenced by the data format many other factors will influence the results. 
Therefore this is more accurately would be described as a survey and analysis of 3D data format _implementations_. 

## Languages and Tools Used

We will examine on JavaScript, WASM, C#, and C++ libraries.     

## Tasks and Measurments

* For each file in the data set we will use various libraries and tools to compute the time and memory consumption to open file and compute:
  * Number of polygons, vertices, indices, meshes (distinct and instanced)
  * average polygon size (total and per-mesh)
  * bounding boxes: globally, total, bounding box
  * average UV coordinate size
  * convert into other formats
  * recognize the file format 
  * find and extract a subset of data
  * modify some part of the data and write it out again.  
  * Time to compress / decompress as zip
  * Compression ratios  

## Format Information

* For each format we will report on: 
  * Support across tools and libraries  
  * Ability to handle different features 
  * References to the specification, and implementations used
  * Binary or text.
  * Availability and links to reference implementations
  
## Data Sets

* Instanced data
* Data with 0, 1, or 2 UV channels
* Data with UVW channels 
* Mixed meshes no instancing
* Conversion time into other format
* Data loss when round-tripped 
* Multiple
* Single and double precisions

## Additional Tasks 

* Represent 2D shapes
* Colored/not-colored
* Point clouds
* Particle sets
* Embedded materials
* Embedded textures 
  
## Formats Considered 

* GLB / glTF
* DAE (Collada)
* OBJ
* STL
* PLY
* FBX
* G3D
* U3D
* USD / USDZ
* Datasmith
* DRC - Draco
* IGES
* MAX - 3ds Max native format
* 3DS
* ABC - Alembic

# Particle and Point Cloud Specific

* PRT
* XYZ
* E57 

# AEC/CAD Specialized Formats

* VIM
* IFC
* BIM 
* STP / STEP
* SVF
* SVF2 (previously known as OTG) 
* DWG 
* 3DM - Rhino format
* DXF -
* 3MF 


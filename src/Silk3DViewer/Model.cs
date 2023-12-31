// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Silk.NET.Assimp;
using Silk.NET.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Vim;
using Vim.LinqArray;
using AssimpMesh = Silk.NET.Assimp.Mesh;

namespace Tutorial
{
    public class Model
    {
        public Model(GL gl, string path)
        {
            _gl = gl;
            LoadModel(path);
        }

        private readonly GL _gl;
        public List<Mesh> Meshes { get; protected set; } = new List<Mesh>();
        
        private void LoadModel(string path)
        {
            var sw = Stopwatch.StartNew();
            path = @"C:\Users\cdigg\Documents\VIM\2023 - Hospital (2).vim";
            var vim = VimScene.LoadVim(path);
            Console.WriteLine($@"Time to open file {sw.Elapsed.TotalSeconds}");

            var g = vim.Document.Geometry;
            Console.WriteLine($"number of meshes {g.Meshes.Count}");
            Console.WriteLine($"number of vertices {g.Vertices.Count}");
            Console.WriteLine($"number of uvs {g.AllVertexUvs.Count}");
            Console.WriteLine($"number of sub-meshes {g.SubmeshIndexCount.Count}");
            Console.WriteLine($"number of faces {g.Indices.Count / 3}");
            Console.WriteLine($"number of instances {g.InstanceMeshes.Count}");
            Console.WriteLine($"number of materials {g.Materials.Count}");

            Meshes.Add(ToMesh(g.Vertices, g.Indices));
        }

        public static Random Random = new Random();

        public Vector4 NewRandomColor()
        {
            return new Vector4(
                Random.NextSingle(), Random.NextSingle(),
                Random.NextSingle(), Random.NextSingle());
        }
        
        public Mesh ToMesh(
            IArray<Vim.Math3d.Vector3> vertices, 
            IArray<int> indices)
        {
            var c = NewRandomColor();
            var vertData = new float[vertices.Count * 6];
            
            for (var i = 0; i < vertices.Count; i++)
            {
                // TODO: 
                if (i % 100 == 0)
                    c = NewRandomColor();

                var vert = vertices[i];
                vertData[i * 6 + 0] = vert.X;
                vertData[i * 6 + 1] = vert.Y;
                vertData[i * 6 + 2] = vert.Z;

                vertData[i * 6 + 3] = c.X;
                vertData[i * 6 + 4] = c.Y;
                vertData[i * 6 + 5] = c.Z;
            }
            var indexData = indices.Select(i => (uint)i).ToArray();
            return new Mesh(_gl, vertData, indexData);
        }
    }
}

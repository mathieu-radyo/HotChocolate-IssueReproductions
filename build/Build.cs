using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    
    [Solution] readonly Solution Solution;
    [Parameter] readonly string Version = "0.0.1";

    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath BinariesDirectory => RootDirectory / "binaries";
    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            TestsDirectory.CreateOrCleanDirectory();
            ArtifactsDirectory.CreateOrCleanDirectory();
            BinariesDirectory.CreateOrCleanDirectory();
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target PublishApi => d => d
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPublish(s => s
                .SetProject(Solution.GetProject("World"))
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .SetOutput(BinariesDirectory));
        });
}

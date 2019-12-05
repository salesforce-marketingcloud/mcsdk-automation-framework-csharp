# MCSDK-Automation-Framework-CSharp

## Overview
This repo is part of the Salesforce Marketing Cloud SDK Automation Framework.

## Contents
- Custom Mustache files [SwaggerCodegen] for C#
- Python Scripts for C# SDK Automation
- Client generator which generates the [Client](https://github.com/salesforce-marketingcloud/mcsdk-automation-csharp/blob/master/src/Salesforce.MarketingCloud/Api/Client.cs) class

## Getting Started

1. If you would like to make changes to the Client generator or the custom mustache files (ApiClient, etc), this is where you would do it. 
2. Make your own branch.
3. Push the changes to your remote branch and create a PR against the most recent version branch from your new branch.
4. This PR would trigger the Travis CI process. 
5. At the end of the CI Process, a new branch would be created on the [SDK Repo](https://github.com/salesforce-marketingcloud/mcsdk-automation-csharp). Also a PR would be created against the most recent version branch in the SDK Repo. 
6. You can then download the SDK project and test the changes on the new branch. 
7. As of now, the process of merging the code to the Master branch is set to Manual for first phase. It would also be automated in future releases. 

## Contact us

- Request a [new feature](https://github.com/salesforce-marketingcloud/mcsdk-automation-framework-csharp/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc), add a question or report a bug on GitHub.
- Vote for [Popular Feature Requests](https://github.com/salesforce-marketingcloud/mcsdk-automation-framework-csharp/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc) by making relevant comments and add your reaction. Use a reaction in place of a "+1" comment:
    - 👍 - upvote
    - 👎 - downvote

## License
By contributing your code, you agree to license your contribution under the terms of the [BSD 3-Clause License](https://github.com/salesforce-marketingcloud/mcsdk-automation-framework-csharp/blob/master/License.md).



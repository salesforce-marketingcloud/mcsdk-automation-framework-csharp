import os
from mcsdk.codebase import codebase
from mcsdk.integration.os.process import Command
from mcsdk.integration.os.utils import chdir


class Setup(codebase.AbstractCodeSetup):
    """ Handles the code setup processes """

    def install_dependencies(self):
        return 0


class Integration(codebase.AbstractCodeIntegration):
    """ Handles the code integration processes """

    def run_tests(self):
        return 0

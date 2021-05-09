var category = {
    init: function () {
        category.loadTree();
        category.loadUpload();
    },
    loadTree: function () {
        var endpoint = "/category/all-categories";
        categories = new kendo.data.HierarchicalDataSource({
            transport: {
                read: {
                    url: endpoint,
                    dataType: "json"
                }
            },
            schema: {
                model: {
                    id: "id",
                    hasChildren: true
                }
            }
        });

        $("#treeview").kendoTreeView({
            checkboxes: true,
            dataSource: categories,
            dataTextField: "title",
            check: category.onCheck,
            select: category.onSelect
        });
    },
    onCheck: function (e) {
        var data = $("#treeview").data('kendoTreeView').dataItem(e.node);
        $("#parentId").val(data.id);
    },
    onSelect: function (e) {
        var data = $("#treeview").data('kendoTreeView').dataItem(e.node);
        category.getFileInfo().enable();
        $.get("/category/edit-category/" + data.id,
            function (data, status) {
                if (data) {
                    document.getElementById("Id").value = data.id;
                    document.getElementById("parentId").value = data.parentId;
                    document.getElementById("Title").value = data.title;
                    document.getElementById("MetaKeyword").value = data.metaKeyword
                    document.getElementById("MetaDescription").value = data.metaDescription;
                    document.getElementById("StatusId").value = data.statusId;
                    document.getElementById("Priority").value = data.priority;
                    $("#image").attr("src", data.imagePath);
                }
            });
    },
    resetForm: function () {
        document.getElementById("frmCategory").reset();
        category.getFileInfo().disable();
        $("#image").attr("src", "");
    },
    reload: function () {
        var tree = $("#treeview").data("kendoTreeView")
        tree.dataSource.read();
        category.getFileInfo().disable();
    },
    loadUpload: function () {
        var url = "/category/upload-category-image/";
        $("#files").kendoUpload({
            async: {
                autoUpload: false,
                saveUrl: url
            },
            upload: function (e) {
                var id = $("#Id").val();
                $("#files").data("kendoUpload").options.async.saveUrl = url + id;
            },
            success: function (e) {
                $(".k-upload-files.k-reset").find("li").remove();
            }
        });
        category.getFileInfo().disable();
    },
    getFileInfo: function () {
        return $("#files").data("kendoUpload");
    },
    submitForm: function () {
        $("form").on("submit", function (event) {
            event.preventDefault();
            $.post('/category/save-category', $(this).serialize(),
                function (data, status) {
                    if (data.success) {
                        toastr.success(data.message);
                    } else {
                        $.each(data.errors, function (key, value) {
                            toastr.error(value);
                        });
                    }
                });
        });
    }
}

function buildTreeFromArray(a) {
	return $.ajax({
    		type: "POST",
    		data: JSON.stringify(a),
    		contentType: "application/json",
    		url:"http://localhost:4664/api/bstree"
    	});
}

function getTreeInfo(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/tree_info"
	});
}

function insertX(tree, x) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/insert?x=" + x
	});
}
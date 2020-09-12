package service.remoteservices;

/**
 * @author Indrit Zeqiri
 * @Github https://github.com/ilstarno
 * @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
 */
public class GDistanceMatrixElement {
	private GDistanceMatrixAtom distance;
	private GDistanceMatrixAtom duration;
	private String status;

	public GDistanceMatrixAtom getDistance() {
		return distance;
	}

	public void setDistance(GDistanceMatrixAtom distance) {
		this.distance = distance;
	}

	public GDistanceMatrixAtom getDuration() {
		return duration;
	}

	public void setDuration(GDistanceMatrixAtom duration) {
		this.duration = duration;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

}